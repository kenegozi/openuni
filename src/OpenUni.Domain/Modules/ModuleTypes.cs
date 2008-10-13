using System.ComponentModel;

namespace OpenUni.Domain.Modules
{
	///	<summary>
	///	Describing types of modules
	///	</summary>
	public enum ModuleTypes
	{
		[Description("ш")]
		Standard,

		[Description("о")]
		Advanced,

		[Description("ос")]
		AdvancedSeminar,

		[Description("ъщ")]
		Masters
	}
}