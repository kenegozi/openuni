<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IDefaultLayout>" %>
<%@ Import Namespace="OpenUni.Web.UI.Controllers"%>
<%@ Import Namespace="OpenUni.Web.UI.Views.Layouts"%>

<div>
	<%if (view.Person!=null) {%>
	שלום <%=view.Person.FullName %>.
	<a href="~<%=view.Site.Login.Logout().Url%>">יציאה</a>	
	<%} else { %>
	<a href="~<%=view.Site.Login.Login("").Url%>">כניסה למערכת</a>
	<%} %>
</div>