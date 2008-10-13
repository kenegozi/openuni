using System.Collections.Generic;
using OpenUni.Domain.Impl.Criteria;
using OpenUni.Domain.Modules;

namespace OpenUni.Domain.Impl.Repositories
{
	/// <summary>
	/// Modules data store implementation
	/// </summary>
	public class ModulesRepository : AbstractActiveRecordBasedRepository, IModulesRepository
	{
		public IEnumerable<Module> FindBy(ModuleSpecification specification)
		{
			return new ModuleSearchCriteria(specification)
				.GetExecutableCriteria(Session)
				.List<Module>();
		}

		public Module Get(int id)
		{
			return Session.Get<Module>(id);
		}
	}
}