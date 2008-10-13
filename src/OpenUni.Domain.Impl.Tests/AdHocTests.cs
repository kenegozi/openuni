using System;
using NUnit.Framework;
using OpenUni.Domain.Modules;

namespace OpenUni.Domain.Impl.Tests
{
	[TestFixture]
	public class AdHocTests
	{
		[Test]
		public void A()
		{
			Console.WriteLine(typeof (IFoo<string[]>).FullName);
		}

	}

	interface IFoo<T>
	{
		
	}
}
