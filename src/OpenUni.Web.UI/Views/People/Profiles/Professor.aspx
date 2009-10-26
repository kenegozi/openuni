﻿<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IShowProfileView<Professor>>" %>
<%@ Import Namespace="OpenUni.Domain.People"%>
<%@ Import Namespace="OpenUni.Web.UI.Views.People.Profiles"%>

<div class="breadcrumbs">
איפה אני? 
<a href="~/">דף הבית</a>
-&gt;
<a href="~<%=Routes.ProfileByPersonDetails(view.PersonToShow.Username, view.PersonToShow.Id)%>">הפרופיל של <%=view.PersonToShow.FullName %></a>
</div>

<div class="person-profile professor-profile>
	<h3>פרופ' <%=view.PersonToShow.FullName%></h3>
	<p>
		<span class="caption">שיוך: </span>
		<a href="~<%=Routes.DepartmentByName(view.PersonToShow.Department.Name) %>"><%=view.PersonToShow.Department.Name%></a>
	</p>
	<p><%=view.PersonToShow.Bio%></p>
</div>
