<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IDefaultLayout>" %>
<%@ Import Namespace="OpenUni.Web.UI.Views.Layouts"%>
<div class="breadcrumbs">
איפה אני? 
<a href="~/">דף הבית</a>
-&gt;
<a href="~<%=Routes.Departments()%>">מחלקות</a>
</div>
מחלקות<br />

<%foreach (var dep in view.Departments) {%>
	<a href="~/departments/<%=dep.Name %>"><%=dep.Name %></a><br />
<%} %>
