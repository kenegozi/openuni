using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
using NUnit.Framework;
using OpenUni.Domain.Impl.Repositories;
using OpenUni.Domain.Modules;

namespace OpenUni.Domain.Impl.Tests
{
	[TestFixture]
	public class ModulesRepositoryTests
	{
		[Test]
		public void Sanity()
		{
			ActiveRecordStarter.Initialize(typeof(Module).Assembly, ActiveRecordSectionHandler.Instance);

			var factory = ActiveRecordMediator.GetSessionFactoryHolder().GetSessionFactory(typeof (ActiveRecordBase));
			var repo = new ModulesRepository {SessionFactory = factory};

			var session = factory.OpenSession();
			NHibernate.Context.CurrentSessionContext.Bind(session);
			repo.AllFor(2009, 1);
		}
	}
}