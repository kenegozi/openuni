using NHibernate;

namespace OpenUni.Domain.Impl.Repositories
{
	/// <summary>
	/// Basic functionality for repositories that uses <c>ActiveRecord</c> entities
	/// </summary>
	public class GenericRepository<TEntity, TKey>
	{
		public ISessionFactory SessionFactory { get; set; }
		/// <summary>
		/// Gets an open <see cref="ISession"/> instance
		/// </summary>
		protected ISession Session
		{
			get { return SessionFactory.GetCurrentSession(); }
		}

		public virtual TEntity LoadBy(TKey id)
		{
			return Session.Load<TEntity>(id);
		}

		public virtual TEntity GetBy(TKey id)
		{
			return Session.Get<TEntity>(id);
		}

		public virtual TEntity Persist(TEntity entity)
		{
			Session.SaveOrUpdate(entity);
			return entity;
		}
	}
}