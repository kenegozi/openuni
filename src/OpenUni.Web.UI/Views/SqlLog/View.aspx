<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IDepartmentShowView>" %>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Import Namespace="OpenUni.Web.UI.Controllers"%>
<%@ Import Namespace="OpenUni.Web.UI.Views.Departments"%>

Total: <%=((List<SqlLogController.DateAndMessage>)(Properties["Queries"])).Count %>
<table style="direction:ltr;">
<thead>
	<th>Date</th>
	<th style="text-align:left;>Query</th>
</thead>
<tbody>
<%foreach(SqlLogController.DateAndMessage q in (List<SqlLogController.DateAndMessage>)Properties["Queries"]) {%>
	<tr>
		<td><%=q.Date.ToShortTimeString() %></td>
		<td><%=q.Query %></td>
	</tr>
<%}%>
</tbody>
</table>
