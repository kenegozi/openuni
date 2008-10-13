using OpenUni.Domain.Departments;

namespace OpenUni.Domain.Modules
{
	public class ModuleInfo
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public Department Department { get; set; }

		public virtual ModuleTypes ModuleType { get; set; }
	}
}