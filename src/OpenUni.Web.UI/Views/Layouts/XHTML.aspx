<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IDefaultLayout>" %>
<%@ Import Namespace="OpenUni.Web.UI"%>

<%@ Import Namespace="OpenUni.Web.UI.Controllers" %>
<%@ Import Namespace="OpenUni.Web.UI.Views.Layouts" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title><%=view.Title??"האוניברסיטה" %></title>
	<link rel="Stylesheet" type="text/css" href="~/static/styles/default.css" />
	<link rel="Stylesheet" type="text/css" href="~/static/js/jquery/jdmenu/jquery.jdMenu.css" />
	<link rel="Stylesheet" type="text/css" href="~/static/js/jquery/jqmodal/jqmodal.css" />
	<link rel="Stylesheet" type="text/css" href="~/static/js/jquery/css/smoothness/jquery-ui-1.7.1.custom.css" />
	<link rel="Stylesheet" type="text/css" href="~/static/js/jquery/jquery.ui.autocomplete.css" />
</head>
<%StartFiltering(new SqlLogFilter()); %>
<body>
	<div class="rtl">
		<div id="canvas">
			<div id="header">
				<h1>האוניברסיטה</h1>
				<subview:loginbox></subview:loginbox>
			</div>
			<div id="content">
				<%=ViewContents %>
			</div>
			<div id="footer">
				<ul>
					<li><a href="~/">דף הבית</a></li>
					<li><a href="~/">צור קשר</a></li>
					<li><a href="~/">קרדיטים</a></li>
				</ul>
			</div>
		</div>
	</div>
	<div id="sqlLogBlocker" class="Covering"></div>
	<div id="sqlLogWrapper" class="Covering">
		<div id="sqlLog"><%=SqlLogFilter.SQL_LOG_PLACEHOLDER %></div>
	</div>
	<div id="sql-log" class="jqmWindow">
		loading ...</div>
	<div id="toggle-sql-log">
		SQL</div>

	<script type="text/javascript" src="~/static/js/jquery/jquery-1.3.2.min.js"></script>
	<script type="text/javascript" src="~/static/js/jquery/jquery-ui-1.7.1.custom.min.js"></script>
	<script type="text/javascript" src="~/static/js/jquery/jdmenu/jquery.bgiframe.js"></script>
	<script type="text/javascript" src="~/static/js/jquery/jdmenu/jquery.dimensions.js"></script>
	<script type="text/javascript" src="~/static/js/jquery/jdmenu/jquery.jdMenu.js"></script>
	<script type="text/javascript" src="~/static/js/jquery/jdmenu/jquery.positionBy.js"></script>
	<script type="text/javascript" src="~/static/js/jquery/jqmodal/jqmodal.js"></script>
	<script type="text/javascript" src="~/static/js/jquery/jquery.ui.autocomplete.ext.js"></script>
	<script type="text/javascript" src="~/static/js/jquery/jquery.ui.autocomplete.js"></script>
	<script type="text/javascript">
		$(function() {
			$('ul.jd_menu').jdMenu();
		});

		$(function() {
			$('.Covering').hide();
			$('div#toggle-sql-log').click(function() {
				$('.Covering').show();
			});

			$('.Covering').click(function(ev) {
				if (ev.target.className !== 'Covering') return;
				$('.Covering').hide();
			});
			$('#sqlLog pre').click(function() {
				$(this).toggleClass('UnCollapsed');
			});
		});
	</script>
<%=Properties["CaptureForEndOfBody"]%>
</body>
<%EndFiltering(); %>
</html>
