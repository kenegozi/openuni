using Castle.Components.DictionaryAdapter;
using Castle.MonoRail.Framework;
using Castle.Tools.CodeGenerator.External;
using OpenUni.Web.UI.SiteMap;
using OpenUni.Web.UI.Views;
using OpenUni.Web.UI.Views.Layouts;

namespace OpenUni.Web.UI.Controllers
{
	public abstract class AbstractController : SmartDispatcherController
	{
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
