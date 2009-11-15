<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IIndexView>" %>
<%@ Import Namespace="OpenUni.Web.UI.Views.Admin.Modules"%>
<div class="breadcrumbs">
איפה אני? 
<a href="~/">דף הבית</a>
-&gt;
<a href="~/admin/home/index">דף הבית למרצה</a>
-&gt;
<a href="~/admin/modules/index?id=<%=view.Module.Id %>">ניהול קורס <%=view.Module%></a>
</div>
<div>
קורס: <%=view.Module%>
</div>
<div>
<a href="students?moduleId=<%=view.Module.Id%>">ניהול ציונים</a>
<br />
<a href="sessions?moduleId=<%=view.Module.Id%>">ניהול מפגשים</a>
</div>
