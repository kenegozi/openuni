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
הרשמה לקורס לסמסטר <%=TermString %>:<br />
בחר קורס: <input id="module" style="width:400px"/><br />
<table id="module-options">
	<thead>
		<tr>
			<th>מס קורס</th>
			<th>שם הקורס</th>
		</tr>
	</thead>
	<tbody></tbody>
</table>
<script type="text/javascript">
var data = [];
<%foreach (var m in Modules) {%> 
data.push({
	name	: '<%=m.Name.Replace("\'","\\\'") %>',
	id		: <%=m.Id %>,
	capacity: <%=m.Capacity %>,
	taken	: <%=m.AlreadyRegistered %>
	  });
<%}%>
</script>
<component:CaptureFor id="CaptureForEndOfBody" append="after">
<script type="text/javascript">
	//var console = { log: function(a) { alert(a); } };
	(function($) {
		$(function() {
			$('#module').keyup(function(e) {
				if (e.keyCode == 13 || e.keyCode == 7)
					return;
				var $this = $(this);
				var searchTerm = $this.val();
				var target = $('#module-options tbody');
				$('tr', target).unbind('click');
				target.html('');
				if (searchTerm.length < 2)
					return;
				var searchExpression = new RegExp(searchTerm);
				var searchResults = [];
				for (var i = 0; i < data.length; ++i) {
					var item = data[i];
					if (item.name.match(searchExpression) || item.id.toString().match(searchExpression))
						searchResults.push(item);
				}

				var target = $('#module-options tbody');
				for (var i = 0; i < searchResults.length; ++i) {
					var item = searchResults[i];
					target.append('<tr>' +
						'<td>' + item.id + '</td>' +
						'<td>' + item.name + '</td>' +
					'<tr>');
				}

				$('tr', target).click(function() {
					alert($(this).find('td')[0].innerHTML);
				});
			});


		});
	})(jQuery);

</script>
</component:CaptureFor>