using Castle.MonoRail.Framework;
using Castle.Tools.CodeGenerator.External;
using OpenUni.Domain.Departments;
using OpenUni.Web.UI.Views.Departments;
using OpenUni.Web.UI.Views.Layouts;

namespace OpenUni.Web.UI.Controllers
{
	[Layout(Layouts.DEFAULT)]
	public partial class DepartmentsController : AbstractController
	{
		private readonly IDepartmentsRepository departmentsRepository;
		public DepartmentsController(IDepartmentsRepository departmentsRepository)
		{
			this.departmentsRepository = departmentsRepository;
		}

		[StaticRoute("Departments", "departments")]
		public void Index()
		{
			LayoutPropertyBag.Departments = departmentsRepository.FindAll();
		}

		[PatternRoute("Department", "department/<departmentName:string>")]
		public void Show(string departmentName)
		{
			LayoutPropertyBag.Departments = departmentsRepository.FindAll();

			var view = DictionaryAdapterFactory.GetAdapter<IDepartmentShowView>(PropertyBag);
			view.Department = departmentsRepository.FindByName(departmentName);

		}
	}
}