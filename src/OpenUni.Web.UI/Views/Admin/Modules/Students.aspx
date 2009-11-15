<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IStudentsView>" %>
<%@ Import Namespace="OpenUni.Web.UI.Views.Admin.Modules"%>
<div class="breadcrumbs">
איפה אני? 
<a href="~/">דף הבית</a>
-&gt;
<a href="~/admin/home/index">דף הבית למרצה</a>
-&gt;
<a href="~/admin/modules/index?id=<%=view.Module.Id %>">ניהול קורס <%=view.Module%></a>
-&gt;
<a href="~/admin/modules/students?moduleId=<%=view.Module.Id %>">ניהול ציונים</a>
</div>
<div>
קורס: <%=view.Module%>
</div>
<div>
<h4>סטודנטים:</h4>
<table>
	<% foreach (var registration in view.Registrations) { %>
	<tr>
		<td><%=registration.Student.ICN %></td>
		<td><%=registration.Student.FullName %></td>
		<td>
			<form action="updateGrade">
				<input type="hidden" name="registrationId" value="<%=registration.Id %>" />
				<input type="text" name="grade" value="<%=registration.Grade %>" />
				<input type="submit" value="עדכון ציון" />
			</form>
		</td>
	</tr>
	<% } %>
</table>
</div>
