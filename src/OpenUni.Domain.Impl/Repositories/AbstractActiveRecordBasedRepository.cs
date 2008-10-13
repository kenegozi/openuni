using Castle.ActiveRecord;
using NHibernate;
using OpenUni.Domain.Departments;

namespace OpenUni.Domain.Impl.Repositories
{
	/// <summary>
	/// Basic functionality for repositories that uses <c>ActiveRecord</c> entities
	/// </summary>
	public class AbstractActiveRecordBasedRepository
	{
		/// <summary>
		/// Gets an open <see cref="ISession"/> instance
		/// </summary>
		protected ISession Session
		{
			get { return ActiveRecordMediator.GetSessionFactoryHolder().CreateSession(typeof(Department)); }
		}

	}
}