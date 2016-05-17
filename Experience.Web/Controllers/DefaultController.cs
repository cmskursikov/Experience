using Microsoft.AspNet.Mvc;

namespace Experience.Web.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index() {
            return View();
        }
        public ActionResult Knockout() {
            return View("Knockout");
        }
		public ActionResult Select2Knockout() {
			return View("Select2FromGithub");
		}
		public ActionResult Components() {
			return View("Components");
		}
	}
}