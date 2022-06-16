using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using FAQ.Interview.Helper;

namespace Faq.Interview.Controllers
{
    public class InterviewController : Controller
    {
        public ActionResult Index(bool showInstructions = false)
        {
            if (showInstructions)
                TempData["SHOW_INSTRUCTIONS"] = "TRUE";
            else
                TempData["SHOW_INSTRUCTIONS"] = "";

            return View();
        }

        public ActionResult SaveData()
        {
            var model = new DinnerViewModel
            {
                Name = "This is a Name",
                Description = "<p>This is a description</p>",
                Sizes = new List<Size>
                {
                    new Size
                    {
                        Name = "Individual",
                        Price = 1.5,
                        Unit = .3
                    },
                    new Size
                    {
                        Name = "Small",
                        Price = 2,
                        Unit = 1
                    },
                    new Size
                    {
                        Name = "Large",
                        Price = 3.5,
                        Unit = 1.5
                    }
                }
            };

            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult SaveData(DinnerViewModel model)
        {
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Sql()
        {
            return View();
        }

        public ActionResult Report(int? month = null)
        {
            //Use this year value
            var year = DateTime.Today.Year;

            var dataProvider = new DataProvider();
            var data = dataProvider.Report(month);

            return View();
        }

        public ActionResult Problem()
        {
            return View();
        }
    }
}