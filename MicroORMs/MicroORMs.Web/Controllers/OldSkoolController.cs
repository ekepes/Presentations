using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using MicroORMs.Web.Models;

namespace MicroORMs.Web.Controllers
{
    public class OldSkoolController : Controller
    {
        //
        // GET: /OldSkool/
        public ActionResult Index()
        {
            IEnumerable<SalesSummaryReportLine> reportLines = GetReportLines();
            return View(reportLines);
        }

        private IEnumerable<SalesSummaryReportLine> GetReportLines()
        {
            // Icky, ugly, crap - never put data access code in a controller (unless you're doing a demo)
            var reportLines = new List<SalesSummaryReportLine>();
            using (var connection = new SqlConnection(ConnectionStrings.Main))
            {
                connection.Open();
                using (var command = new SqlCommand(EmbeddedSql.OldSkoolQueryText, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reportLines.Add(new SalesSummaryReportLine
                                                {
                                                    StateCode = reader.GetString(0),
                                                    SalesYear = reader.GetInt32(1),
                                                    SalesMonth = reader.GetInt32(2),
                                                    MonthlySales = reader.GetDecimal(3)
                                                });
                        }
                    }
                }
            }

            return reportLines;
        }
    }
}