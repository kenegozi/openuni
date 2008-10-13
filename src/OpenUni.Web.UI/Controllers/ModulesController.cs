using Castle.MonoRail.Framework;
using Castle.Tools.CodeGenerator.External;
using OpenUni.Domain.Departments;
using OpenUni.Domain.Modules;
using OpenUni.Web.UI.Views.Layouts;
using OpenUni.Web.UI.Views.Modules;

namespace OpenUni.Web.UI.Controllers
{
	[Layout(Layouts.DEFAULT)]
	public partial class ModulesController : AbstractController
	{
		private readonly IModulesRepository modulesRepository;
		private readonly IDepartmentsRepository departmentsRepository;
		public ModulesController(IModulesRepository modulesRepository, IDepartmentsRepository departmentsRepository)
		{
			this.modulesRepository = modulesRepository;
			this.departmentsRepository = departmentsRepository;
		}

		[StaticRoute("Modules", "modules")]
		public void Index([DataBind("filter")] ModuleSpecification specification)
		{
			LayoutPropertyBag.Departments = departmentsRepository.FindAll();

			var view = DictionaryAdapterFactory.GetAdapter<IIndexView>(PropertyBag);
			view.Modules = modulesRepository.FindBy(specification);
			view.Filter = specification;

		}
	}
}