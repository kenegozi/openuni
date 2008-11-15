<%@ Page Language="C#" Inherits="OpenUni.Web.UI.Views.View<ILoginView>" %>
<%@ Import Namespace="OpenUni.Web.UI.Views.Login"%>

<div class="login-container">
	<form id="login-form" method="post">
		<table>
			<tr>
				<td><label for="username">שם משתמש:</label></td>
				<td><input type="text" name="username" id="username" value="<%=view.Username %>" /></td>
			</tr>
			<tr>
				<td><label for="icn">מס` ת.ז.:</label></td>
				<td><input type="text" name="icn" id="icn" value="<%=view.ICN%>" /></td>
			</tr>
			<tr>
				<td><label for="password">סיסמה:</label></td>
				<td><input type="password" name="password" id="password" /></td>
			</tr>
		</table>
		<input type="submit" value="כניסה" />
	</form>
</div>
