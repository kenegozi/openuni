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
using Castle.Facilities.FactorySupport;
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
using NHibernate;
using NHibernate.Context;
using OpenUni.Domain.Departments;
using OpenUni.Domain.Impl.Repositories;
using OpenUni.Domain.Modules;
using OpenUni.Domain.People;
using OpenUni.Web.UI.Controllers;
using OpenUni.Web.UI.Services.Authentication;
using OpenUni.Web.UI.SiteMap;
using System.Linq;
using IFilter=Castle.MonoRail.Framework.IFilter;

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
			sessionFactory = ActiveRecordMediator.GetSessionFactoryHolder().GetConfiguration(typeof(ActiveRecordBase)).BuildSessionFactory();
			container.Register(Component.For<ISessionFactory>().Instance(sessionFactory));
		}

		private static ISessionFactory sessionFactory;

		static void RegisterFactoryMethod<T>(Func<T> factoryMethod)
		{
			var factory = new GenericFactory<T>(factoryMethod);
			var factoryName = factory.GetType().FullName;
			container.Register(Component.For<GenericFactory<T>>()
								.Instance(factory)
								.Named(factoryName),
							   Component.For<T>()
								.Attribute("factoryId").Eq(factoryName)
								.Attribute("factoryCreate").Eq("Create")
								.LifeStyle.Transient);
		}

		private static void RegisterComponents()
		{
			container.AddFacility("FactorySupportFacility", new FactorySupportFacility());

			RegisterFactoryMethod(() => MonoRailHttpHandlerFactory.CurrentEngineContext);

			//RegisterFactoryMethod(() => sessionFactory.GetCurrentSession());
	
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
			
			var routes = typeof(RouteDefinitions).GetProperties(BindingFlags.Static | BindingFlags.Public)
				.Where(p => p.PropertyType.Name.EndsWith("Route"))
				.Select(r => r.GetGetMethod().Invoke(null, null));

			//var homepageRoute = new HomepageRoute("Homepage");
			//RoutingModuleEx.Engine.Add(homepageRoute);

			foreach (var r in routes)
				RoutingModuleEx.Engine.Add((IRoutingRule)r);
			
		}

		private const string SESSION_KEY = "SESSION_KEY";

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

		protected void Application_EndRequest(object sender, EventArgs e)
		{
			if (ManagedWebSessionContext.HasBind(Context, sessionFactory) == false)
				return;
			var session = sessionFactory.GetCurrentSession();// Context.Items[SESSION_KEY] as ISession;
			if (session==null)
				return;
			if (session.IsOpen)
				session.Close();
			session.Dispose();
			ManagedWebSessionContext.Unbind(Context, sessionFactory);
			//Context.Items.Remove(SESSION_KEY);
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			SetSqlLogging();

			SetIsraelCulture();

			if (Context.Request.Url.PathAndQuery.IndexOf("sqllog",StringComparison.InvariantCultureIgnoreCase) > -1)
				return;

			var session = sessionFactory.OpenSession();
			ManagedWebSessionContext.Bind(Context, session);
			//Context.Items[SESSION_KEY] = session;
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

			configuration.JSGeneratorConfiguration.AddLibrary("jquery-1.2.1", typeof (JQueryGenerator))
				.AddExtension(typeof (CommonJSExtension))
				.ElementGenerator
				.AddExtension(typeof (JQueryElementGenerator))
				.Done
				.BrowserValidatorIs(typeof (JQueryValidator))
				.SetAsDefault();

			configuration.UrlConfig.UseExtensions = false;

		}



		public IWindsorContainer Container
		{
			get { return container; }
		}
	}

	internal class GenericFactory<T>
	{
		readonly Func<T> factoryMethod;

		public GenericFactory(Func<T> factoryMethod)
		{
			this.factoryMethod = factoryMethod;
		}

		public T Create()
		{
			return factoryMethod();
		}
	}
}