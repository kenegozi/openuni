<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IShowProfileView<Person>>" %>
<%@ Import Namespace="OpenUni.Web.UI.Controllers.Portal"%>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Import Namespace="OpenUni.Domain.Modules"%>
<%@ Import Namespace="OpenUni.Domain.People"%>
<%@ Import Namespace="OpenUni.Web.UI.Views.People.Profiles"%>
<script runat="server" type="aspview/properties">
	Guid RegitsrationId;
</script>
ההרשמה בוצעה בהצלחה<br />
מספר הרשמה לבירורים: <%=RegitsrationId %>