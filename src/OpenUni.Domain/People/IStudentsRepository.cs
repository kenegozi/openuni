using System;

namespace OpenUni.Domain.People
{
	public interface IStudentsRepository
	{
		Student Get(Guid id);
	}
}