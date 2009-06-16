<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IDefaultLayout>" %>
<%@ Import Namespace="OpenUni.Web.UI.Views.Layouts"%>
<%=ViewContents %>
<div id="menu">
	<ul class="jd_menu jd_menu_vertical" id="main-menu">
		<li><a href="~<%=Routes.about() %>">אודות האוניברסיטה</a></li>
		<li><a href="~<%=Routes.Departments() %>">מחלקות</a>
			<ul>
				<%foreach (var dep in view.Departments) {%>
				<li><a href="~<%=Routes.DepartmentByName(dep.Name) %>">
					<%=dep.Name %></a></li>
				<%} %>
			</ul>
		</li>
		<li><a href="~<%=Routes.Modules() %>">קורסים</a></li>
	</ul>
</div>
