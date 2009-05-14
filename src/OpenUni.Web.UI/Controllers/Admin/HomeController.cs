using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

using Castle.MonoRail.Framework;
using Castle.MonoRail.Framework.Routing;
using Castle.Tools.CodeGenerator.External;
using OpenUni.Web.UI.Filters;
using OpenUni.Web.UI.Views.Layouts;
using System.Web;

namespace OpenUni.Web.UI.Controllers.Admin
{
	[AdminsOnly]
	[ControllerDetails(Area = "Admin")]
	public abstract class AbstractAdminController : AbstractController
	{
		
	}
	[Layout(Layouts.DEFAULT)]
	public partial class HomeController : AbstractAdminController
	{
		public void Index()
		{
			RenderText("Admin homepage");
		}

	}
}