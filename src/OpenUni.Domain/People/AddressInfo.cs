using Castle.ActiveRecord;

namespace OpenUni.Domain.People
{
	public class AddressInfo
	{
		[Property]
		public virtual string StreetAddress { get; set; }

		[BelongsTo("CityId")]
		public virtual City City { get; set; }

		[Property]
		public virtual int ZipCode { get; set; }
	}
}