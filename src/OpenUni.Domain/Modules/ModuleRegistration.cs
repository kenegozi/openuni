using System;

using Castle.ActiveRecord;

using OpenUni.Domain.People;

namespace OpenUni.Domain.Modules
{
	[ActiveRecord]
	public class ModuleRegistration
	{
		Guid id;
		Person student;
		ModuleAvailability moduleAvailability;

		protected ModuleRegistration()
		{
		}

		public ModuleRegistration(Person student, ModuleAvailability moduleAvailability)
		{
			this.student = student;
			this.moduleAvailability = moduleAvailability;
		}

		[PrimaryKey(Access = PropertyAccess.NosetterCamelcase)]
		public virtual Guid Id
		{
			get { return id; }
		}

		[BelongsTo("StudentId", Access = PropertyAccess.NosetterCamelcase)]
		public virtual Person Student
		{
			get { return student; }
		}

		[BelongsTo("ModuleAvailabilityId", Access = PropertyAccess.NosetterCamelcase)]
		public virtual ModuleAvailability ModuleAvailability
		{
			get { return moduleAvailability; }
		}

	}
}