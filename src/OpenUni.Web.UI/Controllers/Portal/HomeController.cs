using Castle.MonoRail.Framework;
using Castle.Tools.CodeGenerator.External;
using OpenUni.Web.UI.Filters;
using OpenUni.Web.UI.Views.Layouts;

namespace OpenUni.Web.UI.Controllers.Portal
{
	[ControllerDetails(Area = "Portal")]
	[Layout(Layouts.XHTML, Layouts.PORTAL)]
	[StudentsOnly]
	public partial class HomeController : AbstractController
	{
		public void Index()
		{
			PropertyBag["Person"] = Session["Person"];
		}

	}
}