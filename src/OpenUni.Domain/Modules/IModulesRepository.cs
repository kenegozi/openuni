using System.Collections.Generic;

namespace OpenUni.Domain.Modules
{
	/// <summary>
	/// The modules data store
	/// </summary>
	public interface IModulesRepository
	{
		/// <summary>
		/// Find modules by a given specification
		/// </summary>
		/// <param name="specification">The specification to filter by</param>
		/// <returns>Modules that satisfy the given specification</returns>
		IEnumerable<Module> FindBy(ModuleSpecification specification);

		/// <summary>
		/// Gets a Module instance from the data store
		/// </summary>
		/// <param name="id">The id of the module</param>
		/// <returns>Module with Id = id</returns>
		Module Get(int id);
	}
}