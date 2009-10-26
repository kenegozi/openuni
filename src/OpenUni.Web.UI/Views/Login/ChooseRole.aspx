<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IChooseRoleView>" %>
<%@ Import Namespace="OpenUni.Web.UI.Views.Login"%>

<div class="choose-role">
	<h5>שלום <%=view.Person.FullName %></h5>
	<p>בחר תפקיד:</p>
	<form method="post">
	<%if (view.Person.IsInRole(OpenUni.Domain.People.Roles.Student)) {%>
		<input type="radio" name="role" id="role_student" value="<%=OpenUni.Domain.People.Roles.Student %>" />
		<label for="role_student">סטודנט</label>
		<br />
	<%} %>
	<%if (view.Person.IsInRole(OpenUni.Domain.People.Roles.Staff)) {%>
		<input type="radio" name="role" id="role_staff" value="<%=OpenUni.Domain.People.Roles.Staff %>"/>
		<label for="role_staff">סגל אקדמי</label>
		<br />
	<%} %>
	<%if (view.Person.IsInRole(OpenUni.Domain.People.Roles.Admin)) {%>
		<input type="radio" name="role" id="role_admin" value="<%=OpenUni.Domain.People.Roles.Admin %>"/>
		<label for="role_admin">סגל ניהולי</label>
		<br />
	<%} %>
		<input type="submit" value="כניסה" />
	</form>
</div>
