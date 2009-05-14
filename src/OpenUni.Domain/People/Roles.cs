using System;

namespace OpenUni.Domain.People
{
	[Flags]
	public enum Roles
	{
		Admin = 1,
		Student = 2,
		Staff = 4,
	}
}