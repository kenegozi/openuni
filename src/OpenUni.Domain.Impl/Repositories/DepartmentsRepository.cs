using System.Collections.Generic;
using Castle.ActiveRecord;
using NHibernate;
using OpenUni.Domain.Departments;

namespace OpenUni.Domain.Impl.Repositories
{
	public class DepartmentsRepository : IDepartmentsRepository
	{
		private readonly ISessionFactory sessionFactory;

		public DepartmentsRepository(ISessionFactory sessionFactory)
		{
			this.sessionFactory = sessionFactory;
		}

		ISession Session
		{
			get { return sessionFactory.GetCurrentSession(); }
		}

		public IEnumerable<Department> FindAll()
		{
			return Session.CreateQuery("from Department d order by d.Name")
				.SetCacheable(true)
				.List<Department>();
		}

		public Department FindByName(string name)
		{
			return Session.CreateQuery("from Department d where d.Name = :name")
				.SetString("name", name)
				.UniqueResult<Department>();
		}
	}
}