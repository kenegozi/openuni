using Castle.MonoRail.Framework;
using Castle.Tools.CodeGenerator.External;

using OpenUni.Domain.Modules;
using OpenUni.Domain.People;
using OpenUni.Web.UI.Filters;
using OpenUni.Web.UI.Views.Layouts;

namespace OpenUni.Web.UI.Controllers.Portal
{
	[ControllerDetails(Area = "Portal")]
	[Layout(Layouts.PORTAL)]
	[StudentsOnly]
	public partial class ModulesController : AbstractController
	{
		readonly IModulesRepository modulesRepository;

		public ModulesController(IModulesRepository modulesRepository)
		{
			this.modulesRepository = modulesRepository;
		}

		public void MyModules()
		{
			var person = Session["Person"] as Person;
			PropertyBag["MyModules"] = modulesRepository.AllFor(person);
		}

        public void Register()
        {
			var person = Session["Person"] as Person;
			PropertyBag["Modules"] = modulesRepository.AllFor(2009, 3);
		}

	}
}