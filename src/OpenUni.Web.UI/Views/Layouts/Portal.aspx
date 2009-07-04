<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IDefaultLayout>" %>
<%@ Import Namespace="OpenUni.Web.UI.Views.Layouts"%>
<%=ViewContents %>
<div id="menu">
	<ul class="jd_menu jd_menu_vertical" id="main-menu">
		<li><a href="<%=Site.Portal.Modules.MyModules().Url.ToLower() %>">הקורסים שלי</a></li>
		<li><a href="<%=Site.Portal.Modules.Register().Url.ToLower() %>">הרשמה לקורס לסמסטר הקרוב</a></li>
	</ul>	
</div>
