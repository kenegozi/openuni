<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IShowProfileView<Professor>>" %>
<%@ Import Namespace="OpenUni.Domain.People"%>
<%@ Import Namespace="OpenUni.Web.UI.Views.People.Profiles"%>

<div class="person-profile professor-profile>
	<h3>פרופ' <%=view.Person.FullName%></h3>
	<p>
		<span class="caption">שיוך: </span>
		<a href="~<%=Routes.DepartmentByName(view.Person.Department.Name) %>"><%=view.Person.Department.Name%></a>
	</p>
	<p><%=view.Person.Bio%></p>
</div>
