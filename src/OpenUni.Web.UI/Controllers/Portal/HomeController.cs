using Castle.MonoRail.Framework;
using Castle.Tools.CodeGenerator.External;

using OpenUni.Web.UI.Views.Layouts;

namespace OpenUni.Web.UI.Controllers.Portal
{
	[ControllerDetails(Area = "Portal")]
	[Layout(Layouts.PORTAL)]
	public partial class HomeController : AbstractController
	{
		[PatternRoute("PortalHome", "/portal")]
		public void Index()
		{
			PropertyBag["Person"] = Session["Person"];
		}

	}
}