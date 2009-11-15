using System.Collections.Generic;
using OpenUni.Domain.Modules;

namespace OpenUni.Web.UI.Views.Admin.Modules
{
	public interface IStudentsView:IIndexView
	{
		IEnumerable<ModuleRegistration> Registrations { get; set; }
	}
}