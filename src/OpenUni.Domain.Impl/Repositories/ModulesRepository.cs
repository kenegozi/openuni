using System.Collections.Generic;
using OpenUni.Domain.Impl.Criteria;
using OpenUni.Domain.Modules;
using OpenUni.Domain.People;

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

		public IEnumerable<Module> AllFor(Person person)
		{
			var q = @"
				select m
				from ModuleRegistration r
					join r.ModuleAvailability a
					join a.Module m
				where r.Student = :person
				
			";
			return Session.CreateQuery(q)
				.SetEntity("person", person)
				.List<Module>();
		}

		public IEnumerable<Module> AllPrerequisitesFor(int id)
		{
			var q =
				@"with Data AS (
SELECT 0 AS Level, m.Id, m.Name, NULL AS Parent
FROM Modules m 
WHERE m.Id = :id
UNION ALL
SELECT Level + 1, m.Id, m.Name, p.PrerequisitedModuleId AS Parent
FROM Modules m JOIN ModulePrerequisites p on p.ModuleId = m.Id
JOIN Data d on d.Id = p.PrerequisitedModuleId
)
select {m.*} from Data
";
			return Session.CreateSQLQuery(q)
				.SetInt32("id", id)
				.List<Module>();

		}
	}
}