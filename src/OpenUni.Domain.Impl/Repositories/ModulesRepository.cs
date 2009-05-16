using System;
using System.Collections.Generic;
using System.Reflection;
using NHibernate.Transform;
using OpenUni.Domain.Impl.Criteria;
using OpenUni.Domain.Modules;
using OpenUni.Domain.People;
using Module=OpenUni.Domain.Modules.Module;

namespace OpenUni.Domain.Impl.Repositories
{
	/// <summary>
	/// Modules data store implementation
	/// </summary>
	public class ModulesRepository : GenericRepository<Module, int>, IModulesRepository
	{
		public IEnumerable<Module> FindBy(ModuleSpecification specification)
		{
			return new ModuleSearchCriteria(specification)
				.GetExecutableCriteria(Session)
				.List<Module>();
		}

		public IEnumerable<ModuleAvailability> AllFor(int year, byte term)
        {
            var q = @"
				select a
				from ModuleAvailability a
				where   a.Year = :year
                    and a.TermNo = :term
				
			";
            return Session.CreateQuery(q)
                .SetInt32("year", year)
                .SetByte("term", term)
				.List<ModuleAvailability>();
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

		private static readonly ConstructorInfo HierarchicalModuleInfoCtor =
			typeof (ModuleInfoHierarchical).GetConstructor(new[] {typeof (int), typeof (string), typeof (string), typeof (int)});
		public IEnumerable<ModuleInfoHierarchical> AllPrerequisitesFor(int id)
		{
			var q =
				@"with Data AS (
SELECT 0 AS Level, m.Id, m.Name, m.ModuleType, NULL AS Parent
FROM Modules m 
WHERE m.Id = :id
UNION ALL
SELECT Level + 1, m.Id, m.Name, m.ModuleType, p.PrerequisitedModuleId AS Parent
FROM Modules m JOIN ModulePrerequisites p on p.ModuleId = m.Id
JOIN Data d on d.Id = p.PrerequisitedModuleId
)
select Id, Name, ModuleType, Level from Data
";
			return Session.CreateSQLQuery(q)
				.SetInt32("id", id)
				.SetResultTransformer(Transformers.AliasToBeanConstructor(HierarchicalModuleInfoCtor))
				.List<ModuleInfoHierarchical>();

		}
	}
}