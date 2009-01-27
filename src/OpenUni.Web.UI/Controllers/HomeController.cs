using Castle.MonoRail.Framework;
using Castle.Tools.CodeGenerator.External;
using OpenUni.Web.UI.Views.Layouts;
using System.Web;

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
        [Cache(HttpCacheability.Public, MaxAge= TimeSpan.FromHours(1))]
		public void About()
		{

		}
	}
}