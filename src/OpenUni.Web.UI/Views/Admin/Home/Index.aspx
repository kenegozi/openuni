<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IIndexView>" %>
<%@ Import Namespace="OpenUni.Web.UI.Views.Admin.Home"%>
<div class="breadcrumbs">
איפה אני? 
<a href="~/">דף הבית</a>
-&gt;
<a href="~/admin/home/index">דף הבית למרצה</a>
</div>
<div>
שם המרצה: <%=view.Person.FullName %>
</div>
<div>
<h4>קורסים בסמסטר הנוכחי</h4>
<ul>
	<% foreach (var module in view.Modules) { %>
	<li>
		<a href="~/admin/modules/index?id=<%=module.Module.Id %>"><%=module.Module.ToString() %></a>
	</li>
	<%} %>
</ul>
</div>
