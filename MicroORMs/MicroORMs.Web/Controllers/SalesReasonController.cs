using System.Collections.Generic;
using System.Web.Mvc;
using MicroORMs.Web.Models;
using PetaPoco;

namespace MicroORMs.Web.Controllers
{
    public class SalesReasonController : Controller
    {
        //
        // GET: /SalesReason/

        public ActionResult Index()
        {
            IEnumerable<SalesReason> reportLines = GetReportLines();
            return View(reportLines);
        }

        private IEnumerable<SalesReason> GetReportLines()
        {
            // Icky, ugly, crap - never put data access code in a controller (unless you're doing a demo)
            using (var database = GetDatabase())
            {
                var reportLines = database.Fetch<SalesReason>("SELECT * FROM Sales.SalesReason");

                return reportLines;
            }
        }

        private Database GetDatabase()
        {
            return new Database(ConnectionStrings.Main, "System.Data.SqlClient");
        }

        private SalesReason GetSalesReason(int id)
        {
            // Icky, ugly, crap - never put data access code in a controller (unless you're doing a demo)
            using (var database = GetDatabase())
            {
                var reportLines = database.Single<SalesReason>("WHERE SalesReasonID=@0", id);

                return reportLines;
            }
        }

        //
        // GET: /SalesReason/Details/5

        public ActionResult Details(int id)
        {
            SalesReason reason = GetSalesReason(id);
            return View(reason);
        }

        //
        // GET: /SalesReason/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SalesReason/Create

        [HttpPost]
        public ActionResult Create(SalesReason reason)
        {
            try
            {
                // Icky, ugly, crap - never put data access code in a controller (unless you're doing a demo)
                using (var database = GetDatabase())
                {
                    database.Insert(reason);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SalesReason/Edit/5

        public ActionResult Edit(int id)
        {
            SalesReason reason = GetSalesReason(id);
            return View(reason);
        }

        //
        // POST: /SalesReason/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, SalesReason reason)
        {
            try
            {
                // Icky, ugly, crap - never put data access code in a controller (unless you're doing a demo)
                using (var database = GetDatabase())
                {
                    database.Save(reason);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SalesReason/Delete/5

        public ActionResult Delete(int id)
        {
            SalesReason reason = GetSalesReason(id);
            return View(reason);
        }

        //
        // POST: /SalesReason/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, SalesReason reason)
        {
            try
            {
                // Icky, ugly, crap - never put data access code in a controller (unless you're doing a demo)
                using (var database = GetDatabase())
                {
                    database.Delete<SalesReason>(id);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
