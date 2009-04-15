using System.Collections.Generic;
using OpenUni.Domain.Modules;

namespace OpenUni.Web.UI.Views.Modules
{
	public interface IModuleView
	{
		Module Module { get; set; }
		IEnumerable<ModuleInfoHierarchical> PrerequisitedModules { get; set; }
	}
}