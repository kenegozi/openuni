using Castle.ActiveRecord;
using OpenUni.Domain.Departments;
using OpenUni.Domain.People;

namespace OpenUni.Domain.Modules
{
	[ActiveRecord]
	public class Module
	{
		protected Module()
		{
		}

		public Module(int id, string name, Department department, int points, ModuleTypes moduleType, StaffMember director)
		{
			Id = id;
			Name = name;
			Department = department;
			Points = points;
			ModuleType = moduleType;
			Director = director;
		}

		[PrimaryKey(PrimaryKeyType.Assigned)]
		public virtual int Id { get; private set;}

		[Property]
		public virtual string Name { get; private set;}

		[BelongsTo("DepartmentId")]
		public virtual Department Department { get; private set;}

		[Property]
		public virtual int Points { get; set;}

		// DEMO: demonstrating the use of an Enum, mapped to a custom string
		[Property(ColumnType = "D9.NHibernate.UserTypes.DescribedEnumStringType`1[[OpenUni.Domain.Modules.ModuleTypes, OpenUni.Domain]], D9.NHibernate")]
		public virtual ModuleTypes ModuleType { get; private set; }
		
		[BelongsTo("DirectorId")]
		public virtual StaffMember Director { get; private set;}

		public virtual void AssignNewDirector(StaffMember newDirector)
		{
			Director = newDirector;
		}
	}
}