using System;
using Castle.ActiveRecord;
using OpenUni.Domain.Departments;

namespace OpenUni.Domain.People
{
	[ActiveRecord]
	public class StaffMember : Person
	{
		public virtual void SetKey(Guid id)
		{
			Id = id;
		}

		[JoinedKey]
		public override Guid Id { get { return base.Id; } }

		[Property]
		public virtual string Bio { get; set; }

		[BelongsTo("DepartmentId")]
		public virtual Department Department { get; set; }

	}
}