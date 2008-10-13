using NHibernate.Criterion;
using OpenUni.Domain.Modules;

namespace OpenUni.Domain.Impl.Criteria
{
	/// <summary>
	/// A <see cref="DetachedCriteria"/> handling module searches
	/// </summary>
	public class ModuleSearchCriteria : DetachedCriteria
	{
		private readonly ModuleSpecification specification;
		/// <summary>
		/// Creates a new <see cref="DetachedCriteria"/> out of a 
		/// <see cref="ModuleSpecification"/>
		/// </summary>
		public ModuleSearchCriteria(ModuleSpecification specification) 
			: base(typeof(Module), "module")
		{
			this.specification = specification;

			ApplyId();

			ApplyNameContains();
		}

		private void ApplyId()
		{
			if (specification.Id.HasValue == false)
				return;

			Add(Restrictions.Eq("Id", specification.Id.Value));
		}

		void ApplyNameContains()
		{
			if (string.IsNullOrEmpty(specification.NameContains))
				return;

			Add(Restrictions.Like("Name", specification.NameContains, MatchMode.Anywhere));
		}
	}
}