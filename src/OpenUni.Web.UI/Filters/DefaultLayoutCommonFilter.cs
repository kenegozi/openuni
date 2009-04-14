using System;
using Castle.Components.DictionaryAdapter;
using Castle.MonoRail.Framework;
using OpenUni.Domain.Departments;
using OpenUni.Web.UI.Views.Layouts;

namespace OpenUni.Web.UI.Filters
{
	///<summary>
	///Perform common logic for actions rendering to default layout
	///</summary>
	public class DefaultLayoutCommonFilter:IFilter
	{
		private readonly IDepartmentsRepository departmentsRepository;
		private readonly IDictionaryAdapterFactory dictionaryAdapterFactory;
		public DefaultLayoutCommonFilter(IDepartmentsRepository departmentsRepository, IDictionaryAdapterFactory dictionaryAdapterFactory)
		{
			this.departmentsRepository = departmentsRepository;
			this.dictionaryAdapterFactory = dictionaryAdapterFactory;
		}

		public bool Perform(ExecuteWhen exec, IEngineContext context, IController controller, IControllerContext controllerContext)
		{
			if (IsNotGet(context))
				return true;

			if (controllerContext.LayoutNames == null || controllerContext.LayoutNames.Length == 0)
				return true;

			var layout = dictionaryAdapterFactory.GetAdapter<IDefaultLayout>(controllerContext.PropertyBag);
			layout.Departments = departmentsRepository.FindAll();
			return true;
		}

		static bool IsNotGet(IEngineContext context)
		{
			return (context.Request.HttpMethod.Equals("get", StringComparison.InvariantCultureIgnoreCase) == false);
		}
	}
}