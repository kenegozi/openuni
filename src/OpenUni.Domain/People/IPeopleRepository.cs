using System;

namespace OpenUni.Domain.People
{
	///<summary>
	///People data store
	///</summary>
	public interface IPeopleRepository : IRepository<Person, Guid>
	{
	}
}