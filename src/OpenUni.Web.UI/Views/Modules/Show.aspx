<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IModuleView>" %>
<%@ Import Namespace="OpenUni.Web.UI.Views.Modules"%>

<div class="module-details>
	<h3><%=view.Module.Name %> (<%=view.Module.Id %>)</h3>
	<p>
		<span class="caption">שיוך: </span>
		<a href="~<%=Routes.DepartmentByName(view.Module.Department.Name) %>"><%=view.Module.Department.Name %></a>
	</p>
	<p>
		<span class="caption">סוג: </span>
		<%=view.Module.ModuleType%>
	</p>
	<p>
		<span class="caption">מרכז: </span>
		<a href="~/people/<%=view.Module.Director.Id%>"><%=view.Module.Director.FullName%></a>
	</p>
	<p class="description">	<%=view.Module.Description %></p>
	
</div>
