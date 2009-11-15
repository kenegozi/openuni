using Castle.MonoRail.Framework;
using OpenUni.Web.UI.Filters;
using OpenUni.Web.UI.Views.Layouts;

namespace OpenUni.Web.UI.Controllers.Admin
{
	using Domain.People;

	[Layout(Layouts.XHTML, Layouts.DEFAULT)]
	[StaffMembersOnly]
	[ControllerDetails(Area = "Admin")]
	public abstract class AbstractAdminController : AbstractController
	{
		protected StaffMember StaffMember { get; set; }
	}
}