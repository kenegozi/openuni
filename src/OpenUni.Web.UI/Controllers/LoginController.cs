using Castle.MonoRail.Framework;
using Castle.Tools.CodeGenerator.External;

using OpenUni.Domain.People;
using OpenUni.Web.UI.Views.Layouts;
using OpenUni.Web.UI.Views.Login;

namespace OpenUni.Web.UI.Controllers
{
	[Layout(Layouts.DEFAULT)]
	public partial class LoginController : AbstractController<ILoginView>
	{
		IPeopleRepository peopleRepository;

		public LoginController(IPeopleRepository peopleRepository)
		{
			this.peopleRepository = peopleRepository;
		}

		[AccessibleThrough(Verb.Get)]
		[StaticRoute("Login", "login")]
		public void Login(string returnUrl)
		{

		}

		[AccessibleThrough(Verb.Post)]
		public void Login(string returnUrl, int icn, string username, string password)
		{
			var person = peopleRepository.GetByUsername(username);
			if (person==null)
			{
				TryAgain(returnUrl, icn, username);
				return;
			}

			if (person.Password != password)
			{
				TryAgain(returnUrl, icn, username);
				return;
			}

			if (person.ICN != icn)
			{
				TryAgain(returnUrl, icn, username);
				return;
			}

			RenderText("will redirect to " + returnUrl);
		}

		void TryAgain(string returnUrl, int icn, string username)
		{
			var view = Flashed<ILoginView>();
			view.ICN = icn == 0
			           	? string.Empty
			           	: icn.ToString();
			view.Username = username;

			RedirectToUrl(Routes.Login(), "returnUrl=" + returnUrl);
		}
	}
}