using System;
using System.Net;

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

		[PatternRoute("ProfileByPersonDetails", "people/<username>/<personId:guid>")]
		public void Show(string username, Guid personId)
		{
			var person = peopleRepository.GetBy(personId);
			if (person.Username != username)
			{
				RedirectToUrl(Routes.ProfileByPersonDetails(person.Username, personId));
				Response.StatusCode = 301; // permanent redirect
				return;
			}

			PropertyBag["Person"] = person;

			MyViews.Person.Render();

			if (person is StaffMember)
				MyViews.StaffMember.Render();

			if (person is Professor)
				MyViews.Professor.Render();
		}
	}
}