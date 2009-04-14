using System.Net;
using System.Text;
using System.Web;
using Castle.MonoRail.Framework;
using Castle.Tools.CodeGenerator.External;
using OpenUni.Domain.Modules;
using OpenUni.Web.UI.Views.Layouts;
using OpenUni.Web.UI.Views.Modules;

namespace OpenUni.Web.UI.Controllers
{
	[Layout(Layouts.DEFAULT)]
	public partial class ModulesController : AbstractController
	{
		private readonly IModulesRepository modulesRepository;
		public ModulesController(IModulesRepository modulesRepository)
		{
			this.modulesRepository = modulesRepository;
		}

		[PatternRoute("Modules", "modules")]
		public void Index([DataBind("filter")] ModuleSpecification specification)
		{
			var view = Typed<IIndexView>();
			view.Modules = modulesRepository.FindBy(specification);
			view.Filter = specification;
		}

		[PatternRoute("ModuleById", "modules/<moduleId:int>/[moduleName]")]
		public void Show(int moduleId, string moduleName)
		{
			var module = modulesRepository.Get(moduleId);
			if (module == null)
			{
				Error404();
				return;
			}

			var expectedModuleName = module.UrlFriendlyName;
			if (expectedModuleName != moduleName)
			{
				RedirectToUrl(Routes.ModuleById(moduleId, expectedModuleName));
				Response.StatusCode = 301;//permanent redirect
				return;
			}

			var view = Typed<IModuleView>();
			view.Module = module;

		}
	}
}