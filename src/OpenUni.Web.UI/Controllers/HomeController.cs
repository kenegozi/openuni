using Castle.MonoRail.Framework;
using Castle.Tools.CodeGenerator.External;
using OpenUni.Web.UI.Views.Layouts;

namespace OpenUni.Web.UI.Controllers
{
	[Layout(Layouts.DEFAULT)]
	public partial class HomeController : AbstractController
	{
		[StaticRoute("Homepage", "")]
		public void Index()
		{
		}

		[StaticRoute("about", "about")]
		public void About()
		{

		}
	}
}