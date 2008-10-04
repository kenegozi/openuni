using System;
using Castle.ActiveRecord.Framework;
using NHibernate;
using OpenUni.Domain.People;

namespace OpenUni.Domain.Impl.Repositories
{
	public class StudentsRepository : IStudentsRepository
	{
		private readonly ISessionFactoryHolder sessionFactory;
		public StudentsRepository(ISessionFactoryHolder sessionFactory)
		{
			this.sessionFactory = sessionFactory;
		}


		ISession Session { get { return sessionFactory.CreateSession(typeof (Student)); } }

		public Student Get(Guid id)
		{
			return Session.Get<Student>(id);
		}
	}
}