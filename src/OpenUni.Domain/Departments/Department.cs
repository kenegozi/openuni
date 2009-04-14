using System;
using System.Collections.Generic;
using Castle.ActiveRecord;
using OpenUni.Domain.Modules;
using OpenUni.Domain.People;

namespace OpenUni.Domain.Departments
{
	[ActiveRecord(Cache = CacheEnum.ReadWrite)]
	public class Department
	{
		private readonly IList<StaffMember> staff = new List<StaffMember>();
		private readonly IList<Module> modules = new List<Module>();

		[PrimaryKey]
		public virtual Guid Id { get; private set; }

		[Property]
		public virtual string Name { get; set; }


		[HasMany(typeof(StaffMember), Access = PropertyAccess.NosetterCamelcase, OrderBy = "staff0_1_.LastName, staff0_1_.FirstName")]
		public virtual IList<StaffMember> Staff
		{
			get { return staff; }
		}
		[HasMany(typeof(Module), Access = PropertyAccess.NosetterCamelcase, OrderBy = "Name")]
		public virtual IList<Module> Modules
		{
			get { return modules; }
		}
	}
}