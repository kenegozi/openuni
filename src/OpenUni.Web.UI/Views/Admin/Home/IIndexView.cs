using OpenUni.Domain.Modules;
using OpenUni.Domain.People;

namespace OpenUni.Web.UI.Views.Admin.Home
{
	public interface IIndexView
	{
		ModuleAvailability[] Modules { get; set; }
		StaffMember Person { get; set; }
	}
}