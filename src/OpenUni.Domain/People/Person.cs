using System;
using Castle.ActiveRecord;

namespace OpenUni.Domain.People
{
	[ActiveRecord, JoinedBase]
	public class Person
	{
		public Person()
		{
			Address = new AddressInfo();
		}

		[PrimaryKey(PrimaryKeyType.GuidComb)]
		public virtual Guid Id { get; protected set; }

		[Property]
		public virtual int ICN { get; set; }

		[Property]
		public virtual string FirstName { get; set; }

		[Property]
		public virtual string LastName { get; set; }

		[Nested]
		public virtual AddressInfo Address { get; private set; }

	}

	[ActiveRecord]
	public class StaffMember : Person
	{
		//public StaffMember():base(){}

		public virtual void SetKey(Guid id)
		{
			Id = id;
		}

		[JoinedKey]
		public override Guid Id
		{
			get
			{
				return base.Id;
			}
		}

		[Property]
		public virtual string Bio { get; set; }
		[Property]
		public virtual Guid DepartmentId{ get; set; }

	}

}