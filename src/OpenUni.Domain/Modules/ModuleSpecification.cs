using System;
using OpenUni.Domain.Specifications;

namespace OpenUni.Domain.Modules
{
	/// <summary>
	/// Specification for module lookups
	/// </summary>
	public class ModuleSpecification : AbstractPagingAwareSpecification 
	{
		/// <summary>
		/// Optional id - that will turn the specification into a unique one
		/// </summary>
		public int? Id { get; set; }

		/// <summary>
		/// Partial name to look for
		/// Null or empty for no filtering by name
		/// </summary>
		public string NameContains { get; set; }

		/// <summary>
		/// List of module types to filter by. 
		/// Null or empty for no filtering by module type
		/// </summary>
		public ModuleTypes[] Types { get; set; }

		/// <summary>
		/// List of department ids filter by. 
		/// Null or empty for no filtering by department
		/// </summary>
		public Guid[] DepartmentIds { get; set; }
	}
}