<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View" %>

<p class="error">
התוכן המבוקש אינו קיים על השרת. מיד יוצג דף הבית
</p>

<script type="text/javascript">
	setTimeout(function() {
		location.href = '~/';
	}, 4000);
</script>
