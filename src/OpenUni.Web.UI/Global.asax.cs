using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Web;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
using Castle.Components.DictionaryAdapter;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MonoRail.Framework;
using Castle.MonoRail.Framework.Configuration;
using Castle.MonoRail.Framework.Helpers.ValidationStrategy;
using Castle.MonoRail.Framework.Internal;
using Castle.MonoRail.Framework.JSGeneration;
using Castle.MonoRail.Framework.JSGeneration.jQuery;
using Castle.MonoRail.Framework.Routing;
using Castle.MonoRail.Views.AspView;
using Castle.MonoRail.WindsorExtension;
using Castle.Tools.CodeGenerator.External;
using Castle.Windsor;
using D9.Commons;
using OpenUni.Domain.Departments;
using OpenUni.Domain.Impl.Repositories;
using OpenUni.Domain.Modules;
using OpenUni.Domain.People;
using OpenUni.Web.UI.Controllers;
using OpenUni.Web.UI.Services.Authentication;
using OpenUni.Web.UI.SiteMap;
using System.Linq;

namespace OpenUni.Web.UI
{
	public class Global : HttpApplication, IMonoRailConfigurationEvents, IContainerAccessor
	{
		private static WindsorContainer container;

		protected void Application_Start(object sender, EventArgs e)
		{
			log4net.Config.XmlConfigurator.Configure();
			container = new WindsorContainer();
			container.AddFacility("MonoRailFacility", new MonoRailFacility());
			container.AddFacility("LoggingFacility", new LoggingFacility(LoggerImplementation.Log4net));

			Enums.Initialise(typeof(Student).Assembly);

			RegisterComponents();

			InitialiseActiveRecord();

			InitialiseRoutes();

		}

		private static void InitialiseActiveRecord()
		{
			ActiveRecordStarter.Initialize(typeof(Department).Assembly, ActiveRecordSectionHandler.Instance);
		}

		private static void RegisterComponents()
		{
			container.Register(
				AllTypes.Of<Controller>().
					FromAssembly(typeof(HomeController).Assembly),
				AllTypes.Of<IFilter>().
					FromAssembly(typeof(HomeController).Assembly),
				AllTypes.Of<ViewComponent>().FromAssembly(typeof(Global).Assembly)
					.Configure(reg => reg.Named(reg.ServiceType.Name))
			);

			container.Register(
				Component.For<IArgumentConversionService>().ImplementedBy<DefaultArgumentConversionService>().LifeStyle.Transient,
				Component.For<ICodeGeneratorServices>().ImplementedBy<DefaultCodeGeneratorServices>().LifeStyle.Transient,
				Component.For<IControllerReferenceFactory>().ImplementedBy<DefaultControllerReferenceFactory>().LifeStyle.Transient,
				Component.For<IRuntimeInformationService>().ImplementedBy<DefaultRuntimeInformationService>().LifeStyle.Transient);

			container.Register(
				Component.For<IDictionaryAdapterFactory>().ImplementedBy<DictionaryAdapterFactory>().LifeStyle.Transient);

			container.Register(
				Component.For<IRoutingEngine>().Instance(RoutingModuleEx.Engine));

			container.Register(
				Component.For<IFormsAuthentication>().ImplementedBy<DefaultFormsAuthentication>().LifeStyle.Singleton);

			container.Register(
				Component.For<IDepartmentsRepository>().ImplementedBy<DepartmentsRepository>().LifeStyle.Singleton,
				Component.For<IModulesRepository>().ImplementedBy<ModulesRepository>().LifeStyle.Singleton,
				Component.For<IPeopleRepository>().ImplementedBy<PeopleRepository>().LifeStyle.Singleton
				);
		}

		private static void InitialiseRoutes()
		{
			//RoutingModuleEx.Engine.Add(new PatternRoute("<controller>/<action>"));
			/*
			RoutingModuleEx.Engine.Add(
						new PatternRoute("Home", "/[controller]")
								.DefaultForController().Is("Home")
								.DefaultForArea().IsEmpty
								.DefaultForAction().Is("Index")
						);
			*/
			var routes = typeof(RouteDefinitions).GetProperties(BindingFlags.Static | BindingFlags.Public)
				.Where(p => p.PropertyType.Name.EndsWith("Route"))
				.Select(r => r.GetGetMethod().Invoke(null, null));

			var homepageRoute = new HomepageRoute("Homepage");
			RoutingModuleEx.Engine.Add(homepageRoute);

			foreach (var r in routes)
				RoutingModuleEx.Engine.Add((IRoutingRule)r);

		}

		protected void Session_Start(object sender, EventArgs e)
		{

		}

		private void SetSqlLogging()
		{
			if (Request.RawUrl.Contains("sql-log"))
				return;

			log4net.GlobalContext.Properties["page_url"] = Context.Request.RawUrl;

			var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
			if (isAjax == false)
				log4net.GlobalContext.Properties["request_id"] = Context.Request.GetHashCode();
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			SetSqlLogging();

			SetIsraelCulture();
		}

		private static void SetIsraelCulture()
		{
			var israel = CultureInfo.GetCultureInfo("he-il");
			Thread.CurrentThread.CurrentCulture = israel;
			Thread.CurrentThread.CurrentUICulture = israel;
		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{
			container.Dispose();
		}

		/// <summary>
		/// Implementers can take a chance to change MonoRail's configuration.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		public void Configure(IMonoRailConfiguration configuration)
		{
			configuration.ControllersConfig.AddAssembly(Assembly.GetExecutingAssembly());
			configuration.ViewEngineConfig.ViewPathRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Views");
			configuration.ViewEngineConfig.ViewEngines.Add(new ViewEngineInfo(typeof(AspViewEngine), false));

			configuration.JSGeneratorConfiguration.AddLibrary("jquery-1.2.1", typeof(JQueryGenerator))
	.AddExtension(typeof(CommonJSExtension))
	.ElementGenerator
		.AddExtension(typeof(JQueryElementGenerator))
		.Done
	.BrowserValidatorIs(typeof(JQueryValidator))
	.SetAsDefault();

		}



		public IWindsorContainer Container
		{
			get { return container; }
		}
	}

	internal class HomepageRulzComparer : IComparer<string>
	{
		readonly StringComparer comparer = StringComparer.Ordinal;
		public int Compare(string x, string y)
		{
			if (IsHomepage(x))
				return 1;
			if (IsHomepage(y))
				return -1;
			return comparer.Compare(x, y);
		}

		static bool IsHomepage(string str)
		{
			return "homepage".Equals(str, StringComparison.InvariantCultureIgnoreCase);
		}
	}
}