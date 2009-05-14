<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IDefaultLayout>" %>
<%@ Import Namespace="OpenUni.Web.UI.Controllers"%>
<%@ Import Namespace="OpenUni.Web.UI.Views.Layouts"%>

<div>
	<a href="~<%=view.Site.Login.Login("").Url%>">כניסה למערכת</a>
</div>