using System.Collections.Generic;
using Castle.ActiveRecord;
using NHibernate;
using OpenUni.Domain.Departments;

namespace OpenUni.Domain.Impl.Repositories
{
	public class DepartmentsRepository : IDepartmentsRepository
	{
		ISession Session
		{
			get { return ActiveRecordMediator.GetSessionFactoryHolder().CreateSession(typeof (Department)); }
		}

		public IEnumerable<Department> FindAll()
		{
			return Session.CreateQuery("from Department d order by d.Name")
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