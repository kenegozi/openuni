using Castle.MonoRail.Framework;
using OpenUni.Web.UI.Filters;

namespace OpenUni.Web.UI.Controllers.Admin
{
	using Domain.People;

	[AdminsOnly]
	[ControllerDetails(Area = "Admin")]
	public abstract class AbstractAdminController : AbstractController
	{
		protected StaffMember StaffMember { get; set; }
	}
}