using System.Text.RegularExpressions;
using System.Web;
using Castle.ActiveRecord;
using OpenUni.Domain.Departments;
using OpenUni.Domain.People;

namespace OpenUni.Domain.Modules
{
	[ActiveRecord]
	[Import(typeof(ModuleInfo), "ModuleInfo")]
	public class Module
	{
		private int id;
		private string name;
		private ModuleTypes moduleType;

		protected Module()
		{
		}

		public Module(int id, string name, ModuleTypes moduleType)
		{
			this.id = id;
			this.name = name;
			this.moduleType = moduleType;
		}

		[PrimaryKey(PrimaryKeyType.Assigned, Access = PropertyAccess.NosetterCamelcase)]
		public virtual int Id
		{
			get { return id; }
		}

		[Property(Access = PropertyAccess.NosetterCamelcase)]
		public virtual string Name
		{
			get { return name; }
		}

		public virtual string UrlFriendlyName
		{
			get { return nonUrlFriendly.Replace(Name, ""); }
		}
		static readonly Regex nonUrlFriendly = new Regex("[^-a-zà-ú0-9 _,]", RegexOptions.Compiled | RegexOptions.IgnoreCase); 

		[Property]
		public virtual string Description { get; set; }

		[BelongsTo("DepartmentId")]
		public virtual Department Department { get; private set; }

		// DEMO: demonstrating the use of an Enum, mapped to a custom string
		[Property(
			ColumnType = "D9.NHibernate.UserTypes.DescribedEnumStringType`1[[OpenUni.Domain.Modules.ModuleTypes, OpenUni.Domain]], D9.NHibernate",
			Access = PropertyAccess.NosetterCamelcase)]
		public virtual ModuleTypes ModuleType
		{
			get { return moduleType; }
		}

		[BelongsTo("DirectorId")]
		public virtual StaffMember Director { get; set; }
	}
}