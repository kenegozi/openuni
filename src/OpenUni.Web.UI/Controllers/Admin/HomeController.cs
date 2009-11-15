using System.Linq;
using Castle.MonoRail.Framework;
using OpenUni.Domain.Modules;
using OpenUni.Domain.People;
using OpenUni.Web.UI.Filters;
using OpenUni.Web.UI.Views.Admin.Home;
using OpenUni.Web.UI.Views.Layouts;

namespace OpenUni.Web.UI.Controllers.Admin
{
	public partial class HomeController : AbstractAdminController
	{
		private readonly IModulesRepository _modulesRepository;

		public HomeController(IModulesRepository modulesRepository)
		{
			_modulesRepository = modulesRepository;
		}

		public void Index()
		{
			var person = (StaffMember)Session["Person"];
			var view = Typed<IIndexView>();
			view.Person = person;

			var moduleAvailability = _modulesRepository.ModulesForDirector(2009, 1, person.Id);
			view.Modules = moduleAvailability;
		}
	}
}