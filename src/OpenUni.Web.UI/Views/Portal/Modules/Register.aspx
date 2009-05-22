<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IShowProfileView<Person>>" %>
<%@ Import Namespace="OpenUni.Web.UI.Controllers.Portal"%>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Import Namespace="OpenUni.Domain.Modules"%>
<%@ Import Namespace="OpenUni.Domain.People"%>
<%@ Import Namespace="OpenUni.Web.UI.Views.People.Profiles"%>
<script runat="server" type="aspview/properties">
	IEnumerable<ModuleChooseInfo> Modules;
	string TermString;
</script>
הרשמה לקורס לסמסטר <%=TermString %><br />

<%foreach (var m in Modules) {%>
<%=m.Name %>(<%=m.Id %>) מתוך <%=m.Capacity %> מקומות נתפסו כבר <%=m.AlreadyRegistered %><br />
	  
  <%
  }%>
