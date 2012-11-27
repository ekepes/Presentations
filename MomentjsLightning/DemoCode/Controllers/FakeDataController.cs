using System.Web.Mvc;

namespace DemoCode.Controllers
{
    public class FakeDataController : Controller
    {
        public ActionResult GetEvent(string name)
        {
            return Json(new BigEvent(name), JsonRequestBehavior.AllowGet);
        }
    }
}
