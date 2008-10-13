<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IShowProfileView<StaffMember>>" %>
<%@ Import Namespace="OpenUni.Domain.People"%>
<%@ Import Namespace="OpenUni.Web.UI.Views.People.Profiles"%>

<div class="person-profile staff-member-profile>
	<h3><%=view.Person.FullName%></h3>
	<p>
		<span class="caption">שיוך: </span>
		<a href="~<%=Routes.DepartmentByName(view.Person.Department.Name) %>"><%=view.Person.Department.Name%></a>
	</p>
	<p><%=view.Person.Bio%></p>
</div>
