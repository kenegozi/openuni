using System;
using System.Collections.Generic;
using OpenUni.Domain.Departments;

namespace OpenUni.Domain.Impl.Repositories
{
	public class DepartmentsRepository : GenericRepository<Department, Guid>, IDepartmentsRepository
	{
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