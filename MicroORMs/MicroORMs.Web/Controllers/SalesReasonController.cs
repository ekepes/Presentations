using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            Database database = new Database(ConnectionStrings.Main, "System.Data.SqlClient");
            var reportLines = database.Fetch<SalesReason>("SELECT * FROM Sales.SalesReason");
 
            return reportLines;
        }

        //
        // GET: /SalesReason/Details/5

        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
            return View();
        }

        //
        // POST: /SalesReason/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        //
        // POST: /SalesReason/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
