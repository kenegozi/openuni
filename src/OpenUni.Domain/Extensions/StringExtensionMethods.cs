namespace OpenUni.Domain.Extensions
{
	public static class StringExtensionMethods
	{
		public static bool IsNullOrEmpty(this string item)
		{
			return string.IsNullOrEmpty(item);
		}

		public static string Apply(this string format, params object[] arguments)
		{
			return string.Format(format, arguments);
		}
	}
}