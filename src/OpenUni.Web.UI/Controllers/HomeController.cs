using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

using Castle.MonoRail.Framework;
using Castle.MonoRail.Framework.Routing;
using Castle.Tools.CodeGenerator.External;
using OpenUni.Web.UI.Views.Layouts;
using System.Web;

namespace OpenUni.Web.UI.Controllers
{
	[Layout(Layouts.XHTML, Layouts.DEFAULT)]
	public partial class HomeController : AbstractController
	{
		[PatternRoute("Homepage", "/[controller]")]
		public void Index()
		{
		}

		[PatternRoute("about", "/about")]
		[Cache(HttpCacheability.Public, Duration = 60 * 60 * 2)]
		public void About()
		{

		}
	}

	public class HomepageRoute : PatternRoute
	{
		const string HOMEPAGE_PATTERN = "/[controller]";
		const string DEFAULT_ROUTE_NAME = "Homepage";
		/// <summary>
		/// A homepage route named 'Homepage'
		/// </summary>
		public HomepageRoute()
			: this(DEFAULT_ROUTE_NAME)
		{
		}

		/// <summary>
		/// A homepage route named <paramref name="name" />
		/// </summary>
		/// <param name="name">The homepage route's name</param>
		public HomepageRoute(string name)
			: base(name, HOMEPAGE_PATTERN)
		{
			getDefaults = GetGetDefaults();
		}
		/*
		public HomepageRoute DefaultIs<T>(Expression<Action<T>> actionExpression)
			where T : class, IController
		{
			var method = (MethodCallExpression)actionExpression.Body;
			var action = method.Method.Name;
			DefaultForController().Is<T>();
			DefaultForAction().Is(action);
			return this;
		}
		*/

		Func<HomepageRoute, Dictionary<string, string>> GetGetDefaults()
		{
			Func<object, object> getDeafultsFromBase = GetType().BaseType
				.GetField("defaults", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue;

			return (x => (Dictionary<string, string>) getDeafultsFromBase(x));
		}

		/// <summary>
		/// Hack-ish - needed until PatternRoute.defaults is made protected
		/// </summary>
		readonly Func<HomepageRoute, Dictionary<string, string>> getDefaults;

		public override int Matches(string url, IRouteContext context, RouteMatch match)
		{
			var path = context.Request.Uri
				.GetComponents(UriComponents.Path, UriFormat.Unescaped);

			if (Normalise(path).Equals(Normalise(context.ApplicationPath)) == false)
			{
				return 0;
			}
			
			foreach (KeyValuePair<string, string> pair in getDefaults(this))
			{
				if (!match.Parameters.ContainsKey(pair.Key))
				{
					match.Parameters.Add(pair.Key, pair.Value);
				}
			}

			return 100;
		}
		static string Normalise(string path)
		{
			if (path.EndsWith("/") == false)
				path += "/";
			return path;
		}
	}
}