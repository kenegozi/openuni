using Castle.MonoRail.Views.AspView;
using OpenUni.Web.UI.SiteMap;

namespace OpenUni.Web.UI.Views
{
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
	}
}