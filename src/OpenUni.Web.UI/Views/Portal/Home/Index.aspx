<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IShowProfileView<Person>>" %>
<%@ Import Namespace="OpenUni.Domain.People"%>
<%@ Import Namespace="OpenUni.Web.UI.Views.People.Profiles"%>

<div class="person-profile">
	<h3>שלום <%=view.Person.FullName%> וברוך הבא</h3>
</div>
