using System;
using Castle.MonoRail.Framework;
using Castle.Tools.CodeGenerator.External;

using OpenUni.Domain.People;
using OpenUni.Web.UI.Services.Authentication;
using OpenUni.Web.UI.SiteMap;
using OpenUni.Web.UI.Views.Layouts;
using OpenUni.Web.UI.Views.Login;

namespace OpenUni.Web.UI.Controllers
{
	/// <summary>
	/// Login logic
	/// </summary>
	[Layout(Layouts.XHTML, Layouts.DEFAULT)]
	public partial class LoginController : AbstractController<ILoginView>
	{
		#region DI
		readonly IPeopleRepository peopleRepository;
		readonly IFormsAuthentication formsAuthentication;

		/// <summary>
		/// new login controller
		/// </summary>
		/// <param name="peopleRepository">People repository</param>
		/// <param name="formsAuthentication">Forms authentication service</param>
		public LoginController(IPeopleRepository peopleRepository, IFormsAuthentication formsAuthentication)
		{
			this.peopleRepository = peopleRepository;
			this.formsAuthentication = formsAuthentication;
		}
		#endregion

		[AccessibleThrough(Verb.Get)]
		[PatternRoute("Login", "login")]
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

			Session["Person"] = person;
			Response.CreateCookie("uid", person.Id.ToString());
			formsAuthentication.SignOut();
			formsAuthentication.SetAuthenticationCookie(person.Username);

			if (string.IsNullOrEmpty(returnUrl) == false)
			{
				RedirectToUrl(returnUrl);
				return;
			}
			MyActions.ChooseRole().Redirect();
		}

		[PatternRoute("Logout", "login/logout")]
		public void Logout()
		{
			formsAuthentication.SignOut();
			Session["Person"] = null;
			RedirectToUrl("/");
		}

		[AccessibleThrough(Verb.Post)]
		[PatternRoute("Login_ChooseRole", "login/chooserole")]
		public void ChooseRole(Roles role)
		{
			var person = (Person)Session["Person"];
			if (person.IsInRole(role) == false)
			{
				RedirectToReferrer();
				return;
			}
			if (RedirectByRole(role))
				return;

			RedirectToReferrer();
		}

		public void ChooseRole()
		{
			var person = (Person)Session["Person"];
			if (RedirectByRole(person.Roles))
				return;
			PropertyBag["Person"] = person;
		}

		bool RedirectByRole(Roles role)
		{
			if (role == Roles.Staff)
			{
				RedirectToUrl("/");
				return true;
			}
			if (role == Roles.Admin)
			{
				RedirectToUrl("/");
				return true;
			}
			if (role == Roles.Student)
			{
				Site.Portal.Home.Index().Redirect();
				return true;
			}
			return false;
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