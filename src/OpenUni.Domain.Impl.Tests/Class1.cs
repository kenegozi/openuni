using System;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
using D9.Commons;
using NHibernate;
using NUnit.Framework;
using OpenUni.Domain.Modules;
using OpenUni.Domain.People;
// ReSharper disable AccessToStaticMemberViaDerivedType

namespace OpenUni.Domain.Impl.Tests
{
	[TestFixture]
	public class StudentRepositoryTest
	{
		private ISession session;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			//Enums.Initialise(typeof(Student).Assembly);
		}

		[SetUp]
		public void SetUp()
		{
			ActiveRecordStarter.Initialize(typeof(Student).Assembly, ActiveRecordSectionHandler.Instance);

			session = ActiveRecordMediator.GetSessionFactoryHolder().CreateSession(typeof(Student));
		}

		[Test]
		public void A()
		{

			var students = session.CreateQuery(@"
select s
from Student s join s.City c
where 
		s.LastName like :name
  or	c.Name like :name")
				.SetParameter("name", "%א")
				.List<Student>();

		}


		[Test]
		public void Lazy()
		{
			var s = session.CreateQuery("from Student s where s.LastName = :name")
				.SetParameter("name", "אגוזי")
				.List<Student>();

			var c = session.CreateQuery("from City c where exists (from Student s where s.LastName = :name and s.City = c) ")
				.SetParameter("name", "אגוזי")
				.List<City>();

			Console.WriteLine("{0} - {1}", s[0].LastName, s[0].City.Name);

		}

		[Test]
		public void Discriminator()
		{
			var rs = session.CreateQuery("from Assignment r")
				.List<Requirement>();

			foreach (var r in rs)
			{
				Console.WriteLine("{0} - {1}", r.Id, r.GetType().Name);
			}

		}

		[Test]
		public void GetNonStaffPeople()
		{
			var ps = session.CreateQuery("from Person p where p.class <> StaffMember")
				//				.SetParameter("personType", typeof(StaffMember))
				.SetMaxResults(10)
				.List<Person>();

			foreach (var p in ps)
				Console.WriteLine("{0} - {1}", p.Id, p.GetType().Name);

		}

		[Test]
		public void GetPerson()
		{

			var p = session.Load<Person>(new Guid("2bfdedcb-09d3-4f30-ae81-000dfdf4d55c"));

			Console.WriteLine(p.GetType());

		}

		[Test]
		public void UpgradeToStaff()
		{
			var p = session.Load<Person>(new Guid("2bfdedcb-09d3-4f30-ae81-000dfdf4d55c"));
			Console.WriteLine(p.GetType());
			/*
			using (var cmd = session.Connection.CreateCommand())
			{
				cmd.CommandText = "INSERT INTO StaffMembers VALUES (@id, @bio, @did)";
				var par = cmd.CreateParameter();
				par.ParameterName = "id";
				par.Value = p.Id;
				cmd.Parameters.Add(par);
				par = cmd.CreateParameter();
				par.ParameterName = "bio";
				par.Value = "";
				cmd.Parameters.Add(par);
				par = cmd.CreateParameter();
				par.ParameterName = "did";
				par.Value = new Guid("4796E09C-B080-42A1-8873-4734BB169294"); 
				cmd.Parameters.Add(par);
				cmd.ExecuteNonQuery();
			}
			session.Evict(p);
			p  = session.Load<Person>(new Guid("2bfdedcb-09d3-4f30-ae81-000dfdf4d55c"));

			Console.WriteLine(p.GetType());
			*/
		}

		[Test]
		public void Modules()
		{
			var m = session.CreateQuery("from Module m order by Id")
				.SetMaxResults(1) 
				.UniqueResult<Module>();

			Console.WriteLine("[{0}]: {1} / {2}", m.Id, m.ModuleType, m.Director.Id);

		}

	}
}
