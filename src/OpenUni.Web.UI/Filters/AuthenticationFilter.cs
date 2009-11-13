using System;
using System.Collections.Specialized;
using Castle.MonoRail.Framework;
using OpenUni.Domain.People;
using OpenUni.Web.UI.SiteMap;

namespace OpenUni.Web.UI.Filters
{
	public abstract class AuthenticationFilterAttribute : FilterAttribute
	{
		protected AuthenticationFilterAttribute(Type filterType):base(ExecuteWhen.BeforeAction, filterType) {}
	}
	public class AdminsOnlyAttribute : AuthenticationFilterAttribute
	{
		public AdminsOnlyAttribute() : base(typeof(AdminsOnlyFilter))
		{
		}
	}
	public class StaffMembersOnlyAttribute : AuthenticationFilterAttribute
	{
		public StaffMembersOnlyAttribute() : base(typeof(StaffMembersOnlyFilter))
		{
		}
	}
	public class StudentsOnlyAttribute : AuthenticationFilterAttribute
	{
		public StudentsOnlyAttribute() : base(typeof(StudentsOnlyFilter))
		{
		}
	}

	public abstract class AuthenticationFilter : IFilter
	{
		public IPeopleRepository PeopleRepository { get; set; }
		protected abstract Roles RequestedRoles { get; }
		public bool Perform(ExecuteWhen exec, IEngineContext context, IController controller, IControllerContext controllerContext)
		{
			var user = context.Session["Person"] as Person;

			if (user==null)
			{
				var uidInCookie = context.Request.ReadCookie("uid");
				if (string.IsNullOrEmpty(uidInCookie) == false )
				{
					user = PeopleRepository.GetBy(new Guid(uidInCookie));
					context.Session["Person"] = user;
				}
			}

			if (user == null || MatchRequestedRole(user) == false)
				return RedirectToLoginPage(context);

			controllerContext.PropertyBag["Person"] = user;
			return true;
		}

		protected virtual bool MatchRequestedRole(Person user)
		{
			return user.IsInRole(RequestedRoles);
		}

		static bool RedirectToLoginPage(IEngineContext context)
		{
			context.Response.Redirect("", "Login", "Login", new {ReturnUrl = context.Request.Url});
			return false;
		}

	}
	public class AdminsOnlyFilter : AuthenticationFilter
	{
		protected override Roles RequestedRoles
		{
			get { return Roles.Admin; }
		}
	}
	public class StaffMembersOnlyFilter : AuthenticationFilter
	{
		protected override Roles RequestedRoles
		{
			get { return Roles.Staff; }
		}
	}
	public class StudentsOnlyFilter : AuthenticationFilter
	{
		protected override Roles RequestedRoles
		{
			get { return Roles.Student; }
		}
	}
}