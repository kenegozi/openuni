using System.Linq;
using Castle.MonoRail.Framework;
using OpenUni.Domain.Modules;
using OpenUni.Domain.People;
using OpenUni.Web.UI.Views.Layouts;

namespace OpenUni.Web.UI.Controllers.Admin
{
	[Layout(Layouts.DEFAULT)]
	public class HomeController : AbstractAdminController
	{
		private readonly IModulesRepository _modulesRepository;

		public HomeController(IModulesRepository modulesRepository)
		{
			_modulesRepository = modulesRepository;
		}

		public void Index()
		{
			var person = Session["Person"] as Professor;

			var moduleAvailability = _modulesRepository.ModulesForDirector(2009, 1, person.Id);
			var s = moduleAvailability.Select(ma => ma.Module.Name).Aggregate("", (a1, a2) => a1 + "<br/>" + a2);
			RenderText(s);
		}
	}
}