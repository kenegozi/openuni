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

		public class DateAndMessage
		{
			public DateTime Date { get; set; }
			public string Query { get; set; }
			public string Parameters { get; set; }
		}
	}
}