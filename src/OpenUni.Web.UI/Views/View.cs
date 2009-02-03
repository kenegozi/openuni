using System.Web;

using Castle.MonoRail.Views.AspView;

using OpenUni.Domain.Modules;
using OpenUni.Domain.People;
using OpenUni.Web.UI.SiteMap;

namespace OpenUni.Web.UI.Views
{
	public abstract class View : AspViewBase
	{}
	public abstract class View<T> : AspViewBase<T>
	{
		public override void Initialize(AspViewEngine viewEngine, System.IO.TextWriter output, Castle.MonoRail.Framework.IEngineContext context, Castle.MonoRail.Framework.IController controller, Castle.MonoRail.Framework.IControllerContext controllerContext)
		{
			base.Initialize(viewEngine, output, context, controller, controllerContext);
			
			Site = Properties["Site"] as RootAreaNode;
			Routes = new Routes(Context); 
		}

		protected int RequestId { get { return Context.UnderlyingContext.Request.GetHashCode(); } }

		protected RootAreaNode Site { get; private set; }

		protected Routes Routes { get; private set; }

		protected string ProfileUrl(Person p)
		{
			return Routes.ProfileByPersonDetails(p.Username, p.Id);
		}

		protected string ModuleUrl(Module module)
		{
			return Routes.ModuleById(module.Id, module.Name.Replace(":", ""));
		}

		/// <summary>
		/// Adds an entry to the current property bag,
		/// marking the given type for validation helper usage
		/// </summary>
		/// <typeparam name="TValidatedType">The type of the validated entity</typeparam>
		protected void RegisterValidation<TValidatedType>()
		{
			var type = typeof (TValidatedType);
			Context.CurrentControllerContext.PropertyBag.Add(type.Name + "type", type);
		}
	}
}