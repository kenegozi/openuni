using System.Web.Security;

namespace OpenUni.Web.UI.Services.Authentication
{
	/// <summary>
	/// Forms authentication service
	/// </summary>
	public interface IFormsAuthentication
	{
		/// <summary>
		/// Will set an authentication cookie for <paramref name="username"/>
		/// </summary>
		/// <param name="username">The signed in user's user name</param>
		void SetAuthenticationCookie(string username);

		/// <summary>
		/// Will remove the forms authentication ticket
		/// </summary>
		void SignOut();
	}

	/// <summary>
	/// <see cref="IFormsAuthentication"/> implementation based on 
	/// <see cref="FormsAuthentication"/>
	/// </summary>
	public class DefaultFormsAuthentication : IFormsAuthentication
	{
		public void SetAuthenticationCookie(string username)
		{
			FormsAuthentication.SetAuthCookie(username, true);
		}

		public void SignOut()
		{
			FormsAuthentication.SignOut();
		}
	}
}