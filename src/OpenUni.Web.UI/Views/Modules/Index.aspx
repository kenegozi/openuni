<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IIndexView>" %>
<%@ Import Namespace="OpenUni.Web.UI.Views.Modules"%>
<%@ Import Namespace="OpenUni.Web.UI.Views.Layouts"%>

<form method="get" action="">
	<div>
		<h4>חפש לפי:</h4>
		לפי מס' קורס: <input type="text" name="filter.Id" value="<%=view.Filter.Id %>" /><br />
		לפי שם: <input type="text" name="filter.NameContains" value="<%=view.Filter.NameContains%>" /><br />
		<input type="submit" value="חפש" />
	</div>
</form>

<div>
	<h3>קורסים:</h3>
	
	<%foreach (var module in view.Modules) {%>
		<a href="~<%=Routes.ModuleById(module.Id,module.UrlFriendlyName) %>"><%=module.Name %></a><br />
	<%} %>
	
</div>
