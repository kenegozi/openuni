using Castle.MonoRail.Framework;
using Castle.Tools.CodeGenerator.External;
using OpenUni.Domain.Modules;
using OpenUni.Web.UI.Views.Layouts;
using OpenUni.Web.UI.Views.Modules;

namespace OpenUni.Web.UI.Controllers.People
{
	[Layout(Layouts.DEFAULT)]
	public partial class ModulesController : AbstractController
	{
		private readonly IModulesRepository modulesRepository;
		public ModulesController(IModulesRepository modulesRepository)
		{
			this.modulesRepository = modulesRepository;
		}

		[StaticRoute("Modules", "modules")]
		public void Index([DataBind("filter")] ModuleSpecification specification)
		{
			var view = Typed<IIndexView>();
			view.Modules = modulesRepository.FindBy(specification);
			view.Filter = specification;
		}

		[PatternRoute("ModuleById", "modules/<moduleId:int>/<moduleName>")]
		public void Show(int moduleId)
		{
			var view = Typed<IModuleView>();
			view.Module = modulesRepository.Get(moduleId);
		}
	}
}