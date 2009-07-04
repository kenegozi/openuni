using System;
using System.Linq;
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

		public ModuleAvailability GetAvailabilityOf(Module module, int year, byte term)
		{
			return Session.CreateQuery(@"
from ModuleAvailability ma
where	ma.Module = :module
	and	ma.Year = :year
	and ma.TermNo = :term
")
				.SetEntity("module", module)
				.SetInt32("year", year)
				.SetByte("term", term)
				.List<ModuleAvailability>()
				.FirstOrDefault();
		}

		public void SaveRegistraion(ModuleRegistration registration)
		{
			using (var tx = Session.BeginTransaction())
			{
				Session.Save(registration);
				tx.Commit();
			}
		}

		public IEnumerable<object[]> AllFor(int year, byte term, Guid studentId)
        {
            var q = @"
SELECT a.ModuleId, m.Name, a.Capacity, COUNT(mr.Id)
FROM
				ModuleRegistrations mr 
	RIGHT JOIN	ModulesAvailability a ON mr.ModuleAvailabilityId = a.Id
	RIGHT JOIN	Modules m on m.Id = a.ModuleId
WHERE   a.Year = :year
	AND a.TermNo = :term
	AND NOT EXISTS (
		SELECT 1
		FROM ModuleRegistrations mr1
		WHERE	mr1.ModuleAvailabilityId = a.Id
			AND	mr1.StudentId = :studentId
	)
GROUP BY a.ModuleId, m.Name, a.Capacity
HAVING COUNT(mr.Id) < a.Capacity				
			";
            return Session.CreateSQLQuery(q)
				.SetGuid("studentId", studentId)
                .SetInt32("year", year)
                .SetByte("term", term)
				.List<object[]>();
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