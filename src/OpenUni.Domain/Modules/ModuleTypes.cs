using System.ComponentModel;

namespace OpenUni.Domain.Modules
{
	///	<summary>
	///	Describing types of modules
	///	</summary>
	public enum ModuleTypes
	{
		[Description("�")]
		Standard,

		[Description("�")]
		Advanced,

		[Description("��")]
		AdvancedSeminar,

		[Description("��")]
		Masters
	}
}