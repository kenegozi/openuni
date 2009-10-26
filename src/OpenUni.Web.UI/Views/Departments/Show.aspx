<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IDepartmentShowView>" %>
<%@ Import Namespace="OpenUni.Web.UI.Views.Departments"%>
<div class="breadcrumbs">
איפה אני? 
<a href="~/">דף הבית</a>
-&gt;
<a href="~<%=Routes.Departments()%>">מחלקות</a>
-&gt;
<a href="~<%=Routes.DepartmentByName(view.Department.Name)%>"><%=view.Department.Name %></a>
</div>
<div class="department-info">
	<h3><%=view.Department.Name %></h3>
	<h4>חברי צוות:</h4>
	<p>
		<%foreach (var member in view.Department.Staff) {%>
		<a href="<%=ProfileUrl(member)%>"><%=member.FullName %></a><br />
		<%} %>
	</p>
	<h4>קורסים:</h4>
	<p>
		<%foreach (var module in view.Department.Modules) {%>
		<a href="<%=ModuleUrl(module)%>"><%=module.Name %></a><br />
		<%} %>
	</p>
</div>
