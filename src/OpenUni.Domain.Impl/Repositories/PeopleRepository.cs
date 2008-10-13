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
	}
}