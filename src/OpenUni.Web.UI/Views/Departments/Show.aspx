<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IDepartmentShowView>" %>
<%@ Import Namespace="OpenUni.Web.UI.Views.Departments"%>

<div class="department-info">
	<h3><%=view.Department.Name %></h3>
	<h4>חברי צוות:</h4>
	<p>
		<%foreach (var member in view.Department.Staff) {%>
		<a href="<%=Routes.ProfileByPersonId(member.Id)%>"><%=member.FullName %></a><br />
		<%} %>
	</p>
	<h4>קורסים:</h4>
	<p>
		<%foreach (var module in view.Department.Modules) {%>
		<a href="<%=Routes.ModuleById(module.Id, module.Name)%>"><%=module.Name %></a><br />
		<%} %>
	</p>
</div>
