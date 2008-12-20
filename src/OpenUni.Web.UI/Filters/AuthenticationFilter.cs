using Castle.MonoRail.Framework;
using OpenUni.Domain.People;
using OpenUni.Web.UI.SiteMap;

namespace OpenUni.Web.UI.Filters
{
	public class ProfessorsOnlyAttribute : FilterAttribute
	{
		public ProfessorsOnlyAttribute()
			: base(ExecuteWhen.BeforeAction, typeof(ProfessorsOnlyFilter))
		{
		}
	}
	public class StaffMembersOnlyAttribute : FilterAttribute
	{
		public StaffMembersOnlyAttribute()
			: base(ExecuteWhen.BeforeAction, typeof(StaffMembersOnlyFilter))
		{
		}
	}
	public class StudentsOnlyAttribute : FilterAttribute
	{
		public StudentsOnlyAttribute()
			: base(ExecuteWhen.BeforeAction, typeof(StudentsOnlyFilter))
		{
		}
	}

	public abstract class AuthenticationFilter : IFilter
	{
		protected abstract RoleTypes RoleType { get; }
		public bool Perform(ExecuteWhen exec, IEngineContext context, IController controller, IControllerContext controllerContext)
		{
			var user = context.Session["Person"] as Person;

			if (user == null || MatchRequestedRole(user) == false)
				return RedirectToLoginPage(context);

			return true;
		}

		protected virtual bool MatchRequestedRole(Person user)
		{
			return user.GetType().Name.Contains(RoleType.ToString());
		}

		static bool RedirectToLoginPage(IEngineContext context)
		{
			context.Response.RedirectUsingNamedRoute(RouteDefinitions.Login.RouteName);
			return false;
		}

		public enum RoleTypes
		{
			Professor,
			StaffMember,
			Student
		}
	}
	public class ProfessorsOnlyFilter : AuthenticationFilter
	{
		protected override RoleTypes RoleType
		{
			get { return RoleTypes.Professor; }
		}
	}
	public class StaffMembersOnlyFilter : AuthenticationFilter
	{
		protected override RoleTypes RoleType
		{
			get { return RoleTypes.StaffMember; }
		}

	}
	public class StudentsOnlyFilter : AuthenticationFilter
	{
		protected override bool MatchRequestedRole(Person user)
		{
			return true;
		}
		protected override RoleTypes RoleType
		{
			get { return RoleTypes.Student; }
		}
	}
}