using System.Collections.Generic;

namespace OpenUni.Domain.Departments
{
	public interface IDepartmentsRepository
	{
		IEnumerable<Department> FindAll();
		Department FindByName(string name);
	}
}