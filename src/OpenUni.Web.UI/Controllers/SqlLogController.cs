using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Castle.Tools.CodeGenerator.External;

namespace OpenUni.Web.UI.Controllers
{
	public partial class SqlLogController : AbstractController
	{
		[PatternRoute("SqlLog", "sql-log/<requestId:number>")]
		public void View(int requestId)
		{
			var connectionString = ConfigurationManager.ConnectionStrings["OpenU"].ConnectionString;

			var queries = new List<DateAndMessage>();

			using (var con = new SqlConnection(connectionString))
			{
				var query = "SELECT Date, Message FROM SqlLog WHERE RequestId = @RequestId";
				var cmd = new SqlCommand(query, con);
				cmd.Parameters.AddWithValue("@RequestId", requestId);
				con.Open();
				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						queries.Add(
							new DateAndMessage
								{
									Date = reader.GetDateTime(0),
									Query = reader.GetString(1)
								}
							);
					}
				}
			}

			PropertyBag["Queries"] = queries;
		}

		public void Cache()
		{
			var str = "<table>";
			foreach (var item in Context.UnderlyingContext.Cache)
			{
				var key = ((System.Collections.DictionaryEntry) item).Key;
				var value = ((System.Collections.DictionaryEntry)item).Value;
				if (value is System.Collections.DictionaryEntry)
				{
					value = ((System.Collections.DictionaryEntry) value).Key
					        + " - " + ((System.Collections.DictionaryEntry) value).Value;
				}
				str += "<tr><td>" + key + "</td><td>" + value + "</td></tr>";
			}
			str += "</table>";
			RenderText(str);
		}

		public class DateAndMessage
		{
			public DateTime Date { get; set; }
			public string Query { get; set; }
			public string Parameters { get; set; }
		}
	}
}