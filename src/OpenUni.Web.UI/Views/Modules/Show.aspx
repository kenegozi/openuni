<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IModuleView>" %>
<%@ Import Namespace="OpenUni.Web.UI.Views.Modules"%>
<div class="breadcrumbs">
איפה אני? 
<a href="~/">דף הבית</a>
-&gt;
<a href="~<%=Routes.Modules()%>">קורסים</a>
-&gt;
<a href="~<%=Routes.ModuleById(view.Module.Id, view.Module.Name)%>"><%=view.Module.Name %></a>
</div>
<div class="module-details">
	<h3><%=view.Module.Name %> (<%=view.Module.Id %>)</h3>
	<p>
		<span class="caption">שיוך: </span>
		<a href="~<%=Routes.DepartmentByName(view.Module.Department.Name) %>"><%=view.Module.Department.Name %></a>
	</p>
	<p>
		<span class="caption">סוג: </span>
		<%=view.Module.ModuleType%>
	</p>
	<p>
		<span class="caption">מרכז: </span>
		<a href="<%=ProfileUrl(view.Module.Director)%>"><%=view.Module.Director.FullName%></a>
	</p>
	<p class="description">	
		<span class="caption">דרישות קדם:</span>
		<ul>
		<%foreach(var m in view.Module.PrerequisitedModules){ %>
			<li>
				<a href="<%=ModuleUrl(m) %>"><%=m %></a>
			</li>
		<%} %>
		</ul>
	</p>
	<p class="description">	
		<span class="caption">תיאור הקורס:</span><br />
		<%=view.Module.Description %>
	</p>
</div>
