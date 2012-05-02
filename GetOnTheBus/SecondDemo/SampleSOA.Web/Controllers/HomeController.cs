using System;
using System.Web.Mvc;

using MassTransit;

using SampleSOA.Messages;

namespace SampleSOA.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PublishItemPickMessage()
        {
            Bus.Instance.Publish(
                new ItemPicked
                    {
                        ItemId = "Stuff", 
                        AtDeviceId = "Here", 
                        ByUserId = "Me", 
                        EventTime = DateTime.UtcNow, 
                        Quantity = 5
                    });

            return View("Index");
        }
    }
}