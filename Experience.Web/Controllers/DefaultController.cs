using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using System;

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
		public ActionResult FileUploader() {
			return View("FileUploader");
		}
		public ActionResult Sortable() {
			return View("Sortable");
		}
		public ActionResult Validation() {
			return View("Validation");
		}
		[HttpPost]
		public JsonResult fileUpload() {
			var result = false;
			try {
				foreach (IFormFile file in Request.Form.Files) {
					if (file != null) {
						result = true;
					}
				}
			} catch (ArgumentException) { }
			var json = Json(new { result = result, someData = 1});
			return json;
		}
	}
}