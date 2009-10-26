<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IShowProfileView<Person>>" %>
<%@ Import Namespace="System.Linq"%>
<%@ Import Namespace="OpenUni.Web.UI.Services"%>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Import Namespace="OpenUni.Domain.Modules"%>
<%@ Import Namespace="OpenUni.Domain.People"%>
<%@ Import Namespace="OpenUni.Web.UI.Views.People.Profiles"%>
<script runat="server" type="aspview/properties">
	/// <summary>
	/// the modules 
	/// </summary>
	IEnumerable<IGrouping<Term, ModuleRegistration>> MyModules;
</script>

<div class="breadcrumbs">
איפה אני? 
<a href="~/">דף הבית</a>
-&gt;
<a href="~<%=Site.Portal.Home.Index().Url %>">פורטל סטודנטים</a>
-&gt;
<a href="~<%=Site.Portal.Modules.MyModules().Url %>">הקורסים שלי</a>
</div>

<table>
<%foreach (var term in MyModules) {%>
<tr>
	<th colspan="3">סמסטר <%=term.Key %></th>
</tr>
<%foreach (var mr in term) {%>
	<tr>
		<td><%=mr.ModuleAvailability.Module.Id%></td>
		<td><%=mr.ModuleAvailability.Module.Name %></td>
		<td><%=mr.Grade.HasValue?mr.Grade.Value.ToString():"ללא ציון"%></td>
	</tr>	  
<%}%>
<%}%>
</table>
