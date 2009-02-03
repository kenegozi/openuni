namespace OpenUni.Web.UI.Views
{
	public interface IView<T>
	{
		T Item { get; set; }
	}
}