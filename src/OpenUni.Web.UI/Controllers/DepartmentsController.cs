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

		[PatternRoute("Departments", "departments")]
		public void Index()
		{
		}

		[PatternRoute("DepartmentByName", "departments/<departmentName>")]
		public void Show(string departmentName)
		{
			var view = Typed<IDepartmentShowView>();
			view.Department = departmentsRepository.FindByName(departmentName);

		}
	}
}