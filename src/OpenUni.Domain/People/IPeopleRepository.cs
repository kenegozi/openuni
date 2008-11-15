using System;

namespace OpenUni.Domain.People
{
	///<summary>
	///People data store
	///</summary>
	public interface IPeopleRepository : IRepository<Person, Guid>
	{
		/// <summary>
		/// Get by primary key.
		/// </summary>
		/// <param name="username">The person's username</param>
		/// <returns>Entity of T, with the given username</returns>
		Person GetByUsername(string username);
	}
}