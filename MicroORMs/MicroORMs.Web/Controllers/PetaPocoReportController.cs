using System.Collections.Generic;
using System.Web.Mvc;
using MicroORMs.Web.Models;
using PetaPoco;

namespace MicroORMs.Web.Controllers
{
    public class PetaPocoReportController : Controller
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
            Database database = new Database(ConnectionStrings.Main, "System.Data.SqlClient");
            var reportLines = database.Fetch<SalesSummaryReportLine>(EmbeddedSql.OldSkoolQueryText);
            // var reportLines = database.Fetch<SalesSummaryReportLine>(EmbeddedSql.PetaPocoQueryText);

            return reportLines;
        }
    }
}