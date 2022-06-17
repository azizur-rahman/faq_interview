using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            List<WeeklySalaryReport> weeklySalaryReportList = new List<WeeklySalaryReport>();

            if (month != null)
            {
                //Use this year value
                int year = DateTime.Today.Year;

                var dataProvider = new DataProvider();
                var data = dataProvider.Report(month);

                int monthTotalDay = 0, totalWeekOfMonth = 0;
                double weekCalculate = 0;

                monthTotalDay = DateTime.DaysInMonth(year, (int)month);
                weekCalculate = (float)monthTotalDay / 7;
                totalWeekOfMonth = (int)Math.Floor(weekCalculate);

                if (weekCalculate > totalWeekOfMonth)
                {
                    totalWeekOfMonth = totalWeekOfMonth + 1;
                }

                List<WeekMonthCalender> WeekMonthCalenderList = new List<WeekMonthCalender>();

                for (int counter = 1; counter < monthTotalDay; counter++)
                {
                    WeekMonthCalender weekMonthCalObj = new WeekMonthCalender();
                    weekMonthCalObj.MonthName = month.ToString();
                    weekMonthCalObj.DayDate = new DateTime(year, (int)month, counter);
                    weekMonthCalObj.WeekSerialNo = weekMonthCalObj.CalaculateWeekNumber(counter);
                    WeekMonthCalenderList.Add(weekMonthCalObj);
                }

                foreach (var employee in data)
                {
                    WeeklySalaryReport weeklySalaryRptObj = new WeeklySalaryReport();

                    weeklySalaryRptObj.MonthName = month.ToString();
                    weeklySalaryRptObj.EmployeeName = employee.Name;

                    foreach (var weekMonCal in WeekMonthCalenderList)
                    {
                        foreach (var salary in employee.Salaries)
                        {
                            if (weekMonCal.DayDate == salary.Date)
                            {
                                if (weekMonCal.WeekSerialNo == 1)
                                {
                                    weeklySalaryRptObj.Week1 += salary.Amount;
                                }
                                else if (weekMonCal.WeekSerialNo == 2)
                                {
                                    weeklySalaryRptObj.Week2 += salary.Amount;
                                }
                                else if (weekMonCal.WeekSerialNo == 3)
                                {
                                    weeklySalaryRptObj.Week3 += salary.Amount;
                                }
                                else if (weekMonCal.WeekSerialNo == 4)
                                {
                                    weeklySalaryRptObj.Week4 += salary.Amount;
                                }
                                else if (weekMonCal.WeekSerialNo == 5)
                                {
                                    weeklySalaryRptObj.Week5 += salary.Amount;
                                }
                            }

                        }
                    }

                    weeklySalaryReportList.Add(weeklySalaryRptObj);

                }
            }

            return View(weeklySalaryReportList);
        }


        public ActionResult Problem()
        {
            return View();
        }
    }


    public class WeekList
    {
        public string WeekNum { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}