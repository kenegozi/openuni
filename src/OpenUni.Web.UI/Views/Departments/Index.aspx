<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IDefaultLayout>" %>
<%@ Import Namespace="OpenUni.Web.UI.Views.Layouts"%>

מחלקות<br />

<%foreach (var dep in view.Departments) {%>
	<a href="~/departments/<%=dep.Name %>"><%=dep.Name %></a><br />
<%} %>
