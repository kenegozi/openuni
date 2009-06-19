using System;
using System.Collections.Generic;

using OpenUni.Domain.People;

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
        Module GetBy(int id);

		/// <summary>
		/// All available modules for a term and a student, and their registration status,
		/// </summary>
		/// <param name="year">year</param>
		/// <param name="term">team</param>
		/// <param name="studentId">the context student</param>
		/// <returns>module infos</returns>
		IEnumerable<object[]> AllFor(int year, byte term, Guid studentId);

        IEnumerable<Module> AllFor(Person person);

        IEnumerable<ModuleInfoHierarchical> AllPrerequisitesFor(int id);

		ModuleAvailability GetAvailabilityOf(Module module, int year, byte term);

		void SaveRegistraion(ModuleRegistration registration);
    }
}