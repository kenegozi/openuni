<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IShowProfileView<Person>>" %>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Import Namespace="OpenUni.Domain.Modules"%>
<%@ Import Namespace="OpenUni.Domain.People"%>
<%@ Import Namespace="OpenUni.Web.UI.Views.People.Profiles"%>
<script runat="server" type="aspview/properties">
	IEnumerable<ModuleAvailability> Modules;
</script>

<%foreach (var m in Modules) {%>
<%=m.Module.Name %> - <%=m.Capacity %><br />
	  
  <%
  }%>
