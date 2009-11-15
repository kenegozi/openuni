using System;
using System.Linq;
using Castle.MonoRail.Framework;
using OpenUni.Domain.Modules;
using OpenUni.Domain.People;
using OpenUni.Web.UI.Filters;
using OpenUni.Web.UI.Views.Admin.Modules;
using OpenUni.Web.UI.Views.Layouts;

namespace OpenUni.Web.UI.Controllers.Admin
{
	public partial class ModulesController : AbstractAdminController
	{
		private readonly IModulesRepository _modulesRepository;

		public ModulesController(IModulesRepository modulesRepository)
		{
			_modulesRepository = modulesRepository;
		}

		public void Index(int id)
		{
			var module = _modulesRepository.GetBy(id);
			var view = Typed<IIndexView>();
			view.Module = module;
		}
		
		public void Students(int moduleId)
		{
			var module = _modulesRepository.GetBy(moduleId);
			var registrations = _modulesRepository.AllFor(module, 2009, 1);

			var view = Typed<IStudentsView>();
			view.Module = module;
			view.Registrations = registrations;
		}
		public void Sessions(int moduleId)
		{
			RenderText("оегем " + moduleId);

		}

		public void UpdateGrade(Guid registrationId, byte grade)
		{
			var reg = _modulesRepository.GetRegistraionBy(registrationId);
			reg.Grade = grade;
			_modulesRepository.SaveRegistraion(reg);

			RedirectToReferrer();
		}
	}
}