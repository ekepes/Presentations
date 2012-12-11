using System.Web.Mvc;

namespace DemoCode.Controllers
{
    //// http://weblogs.asp.net/bleroy/archive/2008/01/18/dates-and-json.aspx
    public class FakeDataController : Controller
    {
        public ActionResult GetEvent(string name)
        {
            return Json(new BigEvent(name), JsonRequestBehavior.AllowGet);
        }
    }
}
