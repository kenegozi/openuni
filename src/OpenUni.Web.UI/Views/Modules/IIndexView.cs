using System.Collections.Generic;
using OpenUni.Domain.Modules;

namespace OpenUni.Web.UI.Views.Modules
{
	public interface IIndexView
	{
		IEnumerable<Module> Modules { get; set; }
		ModuleSpecification Filter { get; set; }
	}
}