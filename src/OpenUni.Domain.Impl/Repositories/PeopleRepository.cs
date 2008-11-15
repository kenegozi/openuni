using System;
using OpenUni.Domain.People;

namespace OpenUni.Domain.Impl.Repositories
{
	public class PeopleRepository : AbstractActiveRecordBasedRepository, IPeopleRepository
	{
		public Person GetBy(Guid id)
		{
			return Session.Get<Person>(id);
		}

		public Person GetByUsername(string username)
		{
			return Session
				.CreateQuery("from Person p where p.Username = :username")
				.SetString("username", username)
				.UniqueResult<Person>();
		}
	}
}