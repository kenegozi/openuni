using System;
using Castle.ActiveRecord;
using OpenUni.Domain.Extensions;

namespace OpenUni.Domain.People
{
	[ActiveRecord(Cache = CacheEnum.ReadWrite), JoinedBase]
	public class Person
	{
		protected AddressInfo address= new AddressInfo();

		[PrimaryKey(PrimaryKeyType.GuidComb)]
		public virtual Guid Id { get; protected set; }

		[Property]
		public virtual int ICN { get; set; }

		[Property]
		public virtual string Title { get; set; }

		[Property]
		public virtual string FirstName { get; set; }

		[Property]
		public virtual string LastName { get; set; }

		private const string FULL_NAME_FORMAT = "{0} {1}";
		private const string FULL_NAME_WITH_TITLE_FORMAT = "{2} {0} {1}";

		public virtual string FullName
		{
			get
			{
				var format = Title.IsNullOrEmpty()
					? FULL_NAME_FORMAT
					: FULL_NAME_WITH_TITLE_FORMAT;

				return format.Apply(FirstName, LastName, Title);
			}
		}

		[Nested(Access = PropertyAccess.NosetterCamelcase)]
		public virtual AddressInfo Address
		{
			get { return address; }
		}

		[Property]
		public virtual string Username { get; set; }

		[Property]
		public virtual string Password { get; set; }

		[Property]
		public virtual Roles Roles { get; set; }

		public virtual bool IsInRole(Roles role)
		{
			return (Roles & role) == role;
		}

	}
}