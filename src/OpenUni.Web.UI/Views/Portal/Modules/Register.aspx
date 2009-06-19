<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IShowProfileView<Person>>" %>
<%@ Import Namespace="OpenUni.Web.UI.Controllers.Portal"%>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Import Namespace="OpenUni.Domain.Modules"%>
<%@ Import Namespace="OpenUni.Domain.People"%>
<%@ Import Namespace="OpenUni.Web.UI.Views.People.Profiles"%>
<script runat="server" type="aspview/properties">
	IEnumerable<ModuleChooseInfo> Modules;
	string TermString;
	int Year;
	byte Term;
</script>
הרשמה לקורס לסמסטר <%=TermString %>:<br />
חפש קורס (לפי שם או מספר): <input id="module" style="width:400px"/><br />
<table id="module-options">
	<thead>
		<tr>
			<th>מס קורס</th>
			<th>שם הקורס</th>
		</tr>
	</thead>
	<tbody></tbody>
</table>
<form id="registration-form" action="register" method="post" style="display:none">
<span></span><br />
<input type="hidden" name="moduleId" id="moduleId" />
<input type="hidden" name="year" value="<%=Year %>" />
<input type="hidden" name="term" value="<%=Term %>" />
<input type="submit" value="אישור" />
<input type="reset" value="חזור" />
</form>
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
					$('#module-options').hide();
					var form = $('#registration-form');
					var tds = $(this).find('td');
					var moduleName = tds[1].innerHTML;
					var moduleId = tds[0].innerHTML;
					var moduleTitle = moduleName + ' (' + moduleId + ')';
					$('span', form).html('הקורס הנבחר הוא: ' + moduleTitle)
					$('input#moduleId', form).val(moduleId);
					form.show();
				});
			});
			$('#registration-form input[type=reset]').click(function() {
				$('#module-options').show();
				$('#registration-form').hide()
			});
			$('#registration-form input[type=submit]').click(function() {
				var form = $('#registration-form');
				var url = form.attr('action');
				var method = form.attr('method').toUpperCase();
				var data = {
					term: form.find('input[name=term]').val(),
					year: form.find('input[name=year]').val(),
					moduleId: form.find('input[name=moduleId]').val()
				};
				var options = {
					url: url,
					data: data,
					type: method,
					success: function(msg) { alert(msg); },
					error: function(err) { alert('error: ' + err); }
				};
				$.ajax(options);
				return false;
			});
		});
	})(jQuery);

</script>
</component:CaptureFor>