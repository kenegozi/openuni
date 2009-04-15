using System;
using D9.Commons;
using OpenUni.Domain.Departments;

namespace OpenUni.Domain.Modules
{
	public class ModuleInfo
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public ModuleTypes ModuleType { get; set; }
	}

	public class ModuleInfoHierarchical : ModuleInfo
	{
		public int Level { get; set; }
		public ModuleInfoHierarchical()
		{
		}
		public ModuleInfoHierarchical(int id, string name, ModuleTypes moduleType, int level)
		{
			Id = id;
			Name = name;
			ModuleType = moduleType;
			Level = level;
		}
		public ModuleInfoHierarchical(int id, string name, string moduleType, int level)
			:this(id, name, (ModuleTypes)moduleType.ToEnum<ModuleTypes>(),level)
		{
		}
	}
}