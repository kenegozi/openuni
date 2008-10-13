using System;
using Castle.MonoRail.Framework;
using Castle.Tools.CodeGenerator.External;
using OpenUni.Domain.People;
using OpenUni.Web.UI.Views.Layouts;

namespace OpenUni.Web.UI.Controllers.People
{
	[Layout(Layouts.DEFAULT)]
	[ControllerDetails(Area = "People")]
	public partial class ProfilesController : AbstractController
	{
		private readonly IPeopleRepository peopleRepository;
		public ProfilesController(IPeopleRepository peopleRepository)
		{
			this.peopleRepository = peopleRepository;
		}

		[PatternRoute("ProfileByPersonId", "people/<personId:guid>")]
		public void Show(Guid personId)
		{
			var person = peopleRepository.GetBy(personId);
			PropertyBag["Person"] = person;

			MyViews.Person.Render();

			if (person is StaffMember)
				MyViews.StaffMember.Render();

			if (person is Professor)
				MyViews.Professor.Render();
		}
	}
}