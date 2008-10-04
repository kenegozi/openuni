using Castle.MonoRail.Framework;
using Castle.Tools.CodeGenerator.External;
using OpenUni.Domain.Departments;
using OpenUni.Web.UI.Views.Layouts;

namespace OpenUni.Web.UI.Controllers
{
	[Layout(Layouts.DEFAULT)]
	public partial class HomeController : AbstractController
	{
		private readonly IDepartmentsRepository departmentsRepository;
		public HomeController(IDepartmentsRepository departmentsRepository)
		{
			this.departmentsRepository = departmentsRepository;
		}

		[StaticRoute("Homepage", "")]
		public void Index()
		{
			LayoutPropertyBag.Departments = departmentsRepository.FindAll();
		}

		[StaticRoute("about", "about")]
		public void About()
		{

		}
	}
}