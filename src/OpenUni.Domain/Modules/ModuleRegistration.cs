using System;

using Castle.ActiveRecord;

using OpenUni.Domain.People;

namespace OpenUni.Domain.Modules
{
	[ActiveRecord]
	public class ModuleRegistration
	{
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

		[PrimaryKey(PrimaryKeyType.GuidComb)]
		public virtual Guid Id { get; protected set;}

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