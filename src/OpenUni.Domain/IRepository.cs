namespace OpenUni.Domain
{
	///<summary>
	///Acts as data store for entities of type T
	///</summary>
	///<typeparam name="T">The entity type</typeparam>
	///<typeparam name="K">The type for the entity's <c>PrimaryKey</c></typeparam>
	public interface IRepository<T, K>
	{
		/// <summary>
		/// Get by primary key.
		/// </summary>
		/// <param name="id">The entity id</param>
		/// <returns>Entity of T, with the given id</returns>
		T GetBy(K id);
	}
}