<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IDefaultLayout>" %>
<%@ Import Namespace="OpenUni.Web.UI.Views.Layouts"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title><%=view.Title??"האוניברסיטה" %></title>
    <link rel="Stylesheet" type="text/css" href="~/static/styles/default.css" />
    <link rel="Stylesheet" type="text/css" href="~/static/js/jquery/jdmenu/jquery.jdMenu.css" />
    <link rel="Stylesheet" type="text/css" href="~/static/js/jquery/jqmodal/jqmodal.css" />
</head>
<body>
    <div class="rtl" >
		<div id="canvas">
			<div id="header"><h1>האוניברסיטה</h1></div>
			<div id="content">
				<%=ViewContents %>
				<div id="menu">
					<ul class="jd_menu jd_menu_vertical" id="main-menu">
						<li><a href="~<%=Routes.about() %>">אודות האוניברסיטה</a></li>
						<li><a href="~<%=Routes.Departments() %>">מחלקות</a>
							<ul>
							<%foreach (var dep in view.Departments) {%>
								<li><a href="~<%=Routes.DepartmentByName(dep.Name) %>"><%=dep.Name %></a></li>
							<%} %>
							</ul>
						</li>
						<li><a href="~<%=Routes.Modules() %>">קורסים</a></li>
					</ul>
				</div>
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
    <div id="sql-log" class="jqmWindow">loading ...</div>
	<div id="toggle-sql-log">SQL</div>

    <script type="text/javascript" src="~/static/js/jquery/jquery-1.2.6.min.js"></script>
    <script type="text/javascript" src="~/static/js/jquery/jdmenu/jquery.bgiframe.js"></script>
    <script type="text/javascript" src="~/static/js/jquery/jdmenu/jquery.dimensions.js"></script>
    <script type="text/javascript" src="~/static/js/jquery/jdmenu/jquery.jdMenu.js"></script>
    <script type="text/javascript" src="~/static/js/jquery/jdmenu/jquery.positionBy.js"></script>
    <script type="text/javascript" src="~/static/js/jquery/jqmodal/jqmodal.js"></script>
    
    <script type="text/javascript">
		$(document).ready(function() {
			$('ul.jd_menu').jdMenu();
		});
		
		$(document).ready(function() {
			$('div#sql-log').hide();
			$('div#sql-log').jqm({
				ajax: '~/sql-log/<%=RequestId %>', trigger: 'div#toggle-sql-log'
			});
		});
/*		
		$('#toggle-sql-log').click(function() {
			
			var body = $(document.body);
			var bodyDimensions = {
				width	: body.innerWidth(),
				height	: body.innerHeight()
			};
			
			var sqlLog = $('div#sql-log');
			var logDimensions = {
				width	: sqlLog.outerWidth(),
				height	: sqlLog.outerHeight()
			};
			
			var top = (bodyDimensions.height - logDimensions.height) / 2;
			if ( top < 0 ) top = 0;
			
			var left = (bodyDimensions.width - logDimensions.width) / 2;
			
			sqlLog
				.css({top : top, left: left})
				.show();
		});
		*/
    </script>
</body>
</html>
