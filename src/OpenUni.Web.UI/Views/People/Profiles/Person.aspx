<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IShowProfileView<Person>>" %>
<%@ Import Namespace="OpenUni.Domain.People"%>
<%@ Import Namespace="OpenUni.Web.UI.Views.People.Profiles"%>

<div class="breadcrumbs">
איפה אני? 
<a href="~/">דף הבית</a>
-&gt;
<a href="~<%=Routes.ProfileByPersonDetails(view.PersonToShow.Username, view.PersonToShow.Id)%>">הפרופיל של <%=view.PersonToShow.FullName %></a>
</div>

<div class="person-profile">
	<h3><%=view.PersonToShow.FullName%></h3>
</div>
