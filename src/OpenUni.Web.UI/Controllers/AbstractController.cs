using System;
using System.Web;
using Castle.Components.DictionaryAdapter;
using Castle.MonoRail.Framework;
using Castle.Tools.CodeGenerator.External;
using OpenUni.Web.UI.Filters;
using OpenUni.Web.UI.SiteMap;
using OpenUni.Web.UI.Views;
using OpenUni.Web.UI.Views.Layouts;

namespace OpenUni.Web.UI.Controllers
{
	[Filter(ExecuteWhen.AfterAction, typeof(DefaultLayoutCommonFilter))]
	public abstract class AbstractController : SmartDispatcherController
	{
		protected override object InvokeMethod(System.Reflection.MethodInfo method, IRequest request, System.Collections.Generic.IDictionary<string, object> extraArgs)
		{
			Response.CachePolicy.SetCacheability(HttpCacheability.NoCache);
			Response.CachePolicy.SetExpires(DateTime.Now.AddYears(-1));
			Response.CachePolicy.SetNoStore();
			var result = base.InvokeMethod(method, request, extraArgs);
			PropertyBag["Person"] = Session["Person"];
			return result;
		}
		public IDictionaryAdapterFactory DictionaryAdapterFactory
		{
			get;
			set;
		}

		public ICodeGeneratorServices CodeGeneratorServices
		{
			get;
			set;
		}
		protected RootAreaNode Site;

		/// <summary>
		/// Provides typed access to the property bag
		/// </summary>
		/// <typeparam name="T">Interface through with an access to the property bag is
		/// needed</typeparam>
		/// <returns>A typed wrapper around PropertyBag of type T</returns>
		public T Typed<T>()
		{
			return DictionaryAdapterFactory.GetAdapter<T>(PropertyBag);
		}

		/// <summary>
		/// Provides typed access to the flash
		/// </summary>
		/// <typeparam name="T">Interface through with an access to the flash is
		/// needed</typeparam>
		/// <returns>A typed wrapper around flash of type T</returns>
		public T Flashed<T>()
		{
			return DictionaryAdapterFactory.GetAdapter<T>(Flash);
		}

		protected Routes Routes{ get; private set;}

		protected virtual void PerformGeneratedInitialize()
		{
			Routes = new Routes(Context);
			CodeGeneratorServices.RailsContext = Context;
			CodeGeneratorServices.Controller = this;
			Site = new RootAreaNode(CodeGeneratorServices);
			var view = DictionaryAdapterFactory.GetAdapter<ISiteAwareView>(PropertyBag);
			view.Site = Site;
		}
		public override void Initialize()
		{
			base.Initialize();
			PerformGeneratedInitialize();
		}

		private IDefaultLayout layoutFlash;
		protected IDefaultLayout LayoutFlash
		{
			get
			{
				if (layoutFlash == null)
					layoutFlash = DictionaryAdapterFactory.GetAdapter<IDefaultLayout>(Flash);
				return layoutFlash;
			}
		}

		private IDefaultLayout layoutPropertyBag;
		protected IDefaultLayout LayoutPropertyBag
		{
			get
			{
				if (layoutPropertyBag == null)
					layoutPropertyBag = DictionaryAdapterFactory.GetAdapter<IDefaultLayout>(PropertyBag);
				return layoutPropertyBag;
			}
		}

		protected void Error404()
		{
			RenderView("/Errors/Error404");
			Response.StatusCode = 404;
		}
	}

	public abstract class AbstractController<TView> : AbstractController
	{
		private TView typedPropertyBag;
		protected TView TypedPropertyBag
		{
			get
			{
				if (typedPropertyBag == null)
					typedPropertyBag = DictionaryAdapterFactory.GetAdapter<TView>(PropertyBag);
				return typedPropertyBag;
			}
		}
	}
}
