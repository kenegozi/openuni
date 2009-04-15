using System.Text.RegularExpressions;

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

		public static string Friendlify(this string url)
		{
			return nonUrlFriendly.Replace(url, ""); ;
		}

		static readonly Regex nonUrlFriendly = new Regex("[^-a-zà-ú0-9 _,]", RegexOptions.Compiled | RegexOptions.IgnoreCase); 

	}
}