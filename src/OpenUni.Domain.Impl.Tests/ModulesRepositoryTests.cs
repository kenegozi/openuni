using System;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
using NUnit.Framework;
using OpenUni.Domain.Impl.Repositories;
using OpenUni.Domain.Modules;
using OpenUni.Domain.People;

namespace OpenUni.Domain.Impl.Tests
{
	[TestFixture]
	public class ModulesRepositoryTests
	{
		[Test]
		public void Sanity()
		{
			ActiveRecordStarter.Initialize(typeof(Module).Assembly, ActiveRecordSectionHandler.Instance);

			var factory = ActiveRecordMediator.GetSessionFactoryHolder().GetSessionFactory(typeof (ActiveRecordBase));
			var repo = new ModulesRepository {SessionFactory = factory};

			var session = factory.OpenSession();
			NHibernate.Context.CurrentSessionContext.Bind(session);
			repo.AllFor(2009, 1, Guid.NewGuid());
		}

		[Test]
		public void CanRegister()
		{
			ActiveRecordStarter.Initialize(typeof(Module).Assembly, ActiveRecordSectionHandler.Instance);

			var factory = ActiveRecordMediator.GetSessionFactoryHolder().GetSessionFactory(typeof(ActiveRecordBase));
			var repo = new ModulesRepository { SessionFactory = factory };
			var session = factory.OpenSession();
			NHibernate.Context.CurrentSessionContext.Bind(session);
			var person = session.CreateQuery("from Person").SetMaxResults(1).UniqueResult<Person>();
			var moduleAvailability = session.CreateQuery("from ModuleAvailability ma").SetMaxResults(1).UniqueResult<ModuleAvailability>();
			var reg = new ModuleRegistration(person, moduleAvailability);
			repo.SaveRegistraion(reg);

			session.Flush();
			session.Clear();
			Console.WriteLine(reg.ToString());

			var r = session.CreateQuery("from ModuleRegistration r where r.Student = :student")
				.SetEntity("student", person)
				.UniqueResult<ModuleRegistration>();

			Console.WriteLine(r.ToString());
		}
	}
}