using System;
using Castle.ActiveRecord;

namespace OpenUni.Domain.People
{
	[ActiveRecord]
	public class Professor : StaffMember
	{
		[JoinedKey]
		public override Guid Id { get { return base.Id; } }
	}
}