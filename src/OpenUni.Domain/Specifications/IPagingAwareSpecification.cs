namespace OpenUni.Domain.Specifications
{
	/// <summary>
	/// Marks a class as a specification the support paging
	/// </summary>
	public interface IPagingAwareSpecification : ISpecification
	{
		/// <summary>
		/// The page number to retrieve
		/// </summary>
        int Page { get; set; }

		/// <summary>
		/// The page size
		/// </summary>
		int PageSize { get; set; }
		
	}
}