using System.Collections.Generic;
using OpenUni.Domain.Departments;

namespace OpenUni.Web.UI.Views.Layouts
{
	public interface IDefaultLayout : ISiteAwareView
	{
		string Title { get; set; }
		IEnumerable<Department> Departments { get; set;}
	}
}