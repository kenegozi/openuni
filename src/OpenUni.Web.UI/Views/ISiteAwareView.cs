using OpenUni.Domain.People;
using OpenUni.Web.UI.SiteMap;

namespace OpenUni.Web.UI.Views
{
	public interface ISiteAwareView
	{
		RootAreaNode Site { get; set; }
		Person Person { get; set; }
	}
}