using System;
using Castle.ActiveRecord;

namespace OpenUni.Domain.Departments
{
	[ActiveRecord]
	public class Department
	{
		[PrimaryKey]
		public virtual Guid Id { get; private set; }

		[Property]
		public virtual string Name { get; set; }
	
	}
}
