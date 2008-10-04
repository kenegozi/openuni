using Castle.MonoRail.Views.AspView;

namespace OpenUni.Web.UI.Views
{
	public abstract class View<T> : AspViewBase<T>
	{
		protected int RequestId { get { return Context.UnderlyingContext.Request.GetHashCode(); } }
	}
}