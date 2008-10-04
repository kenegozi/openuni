using System;
using Castle.ActiveRecord;

namespace OpenUni.Domain
{
	[ActiveRecord]
	public class City
	{
		[PrimaryKey]
		public virtual Guid Id { get; protected set; }

		[Property]
		public virtual string Name { get; set; }
	}
}