using Castle.MonoRail.Framework;
using OpenUni.Web.UI.Attributes;

namespace OpenUni.Web.UI.Controllers
{
	public class TestController : SmartDispatcherController
	{
		public void Test([BindFrom("User.Age")]int age)
		{
			RenderText("Ages is " + age);
		}

	}
}