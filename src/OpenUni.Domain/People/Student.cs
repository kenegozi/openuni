using System;
using Castle.ActiveRecord;

namespace OpenUni.Domain.People
{
	[ActiveRecord(Lazy=true)]
	public class Student 
	{
		[PrimaryKey]
		public virtual Guid Id { get; protected set; }

		[Property]
		public virtual string LastName { get; set; }
		
		[BelongsTo("CityId")]
		public virtual City City { get; set; }
	}
}