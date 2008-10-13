using OpenUni.Domain.People;

namespace OpenUni.Web.UI.Views.People.Profiles
{
	public interface IShowProfileView<T>
		where T : Person
	{
		T Person { get; set; }
	}
}