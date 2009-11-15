
<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<IIndexView>" %>
<%@ Import Namespace="OpenUni.Web.UI.Views.Home"%>
<div class="breadcrumbs">
איפה אני? 
<a href="~/">דף הבית</a>
-&gt;
<a href="~<%=Routes.about()%>">אודות</a>
</div>
<div id="about">
<p>אתר המדגים מערכת ניהול לאוניברסיטה</p>
<p>	נכתב על ידי חן אגוזי, עבור  סדנה בבסיסי נתונים (מס' קורס 20563) באוניברסיטה הפתוחה</p>
<br />
<br />
<br />
<p>האתר עושה שימוש בטכנולוגיות הבאות:</p>
<div class="tech">
	<p>מנהל בסיס נתונים</p>
	<ul> 
		<li><a href="http://www.microsoft.com/sql/editions/express/default.mspx">Microsoft SQL Server 2005</a></li>
		<li><a href="http://www.amazon.com/dp/0735623139?tag=kenegoziswebl-20">T-SQL Language</a></li>
	</ul>
</div>

<div class="tech">
	<p>שרת אפליקציה</p>
	<ul>
		<li><a href="http://www.asp.net/">Microsoft ASP.NET 2.0</a></li>
		<li><a href="http://www.scribd.com/doc/43206/csharp-3-0-specification">c# 3.0</a></li>
		<li><a href="http://www.castleproject.org/container/index.html">Castle Windsor - IoC container</a></li>
		<li><a href="http://www.castleproject.org/MonoRail/">Castle MonoRail - MVC framework</a></li>
	</ul>
</div>

<div class="tech">
	<p>Data Access and OR/M</p>
	<ul>
		<li><a href="http://www.nhforge.org">NHibernate 2.1</a></li>
		<li><a href="http://www.castleproject.org/activerecord/index.html">Castle ActiveRecord</a></li>
	</ul>
</div>

<div class="tech">
	<p>ממשק משתמש</p>
	<ul>
		<li><a href="http://www.w3schools.com/xhtml/default.asp">X/HTML</a></li>
		<li><a href="http://http://www.w3schools.com/js/default.asp">javascript</a></li>
		<li><a href="http://docs.jquery.com/Main_Page">jQuery</a></li>
	</ul>
</div>

</div>
