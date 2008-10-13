namespace OpenUni.Domain.Specifications
{
	/// <summary>
	/// Case class for specifications that allow paging
	/// </summary>
	public class AbstractPagingAwareSpecification : IPagingAwareSpecification
	{
		public int Page
		{
			get;
			set;
		}

		public int PageSize
		{
			get;
			set;
		}
	}
}