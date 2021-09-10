using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PcHut.Models;
using PcHut.Repository;

namespace PcHut.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            SalesRepository salesRepository = new SalesRepository();

            List<SumGroupByModel> yearlySalesInfo = salesRepository.GetYearlySalesData();
            //return Ok(yearlySalesInfo);
            return View(yearlySalesInfo);
        }

        public ActionResult MonthlySalesForYearReport(int id)
        {
            SalesRepository salesRepository = new SalesRepository();

            List<SumGroupByModel> monthlyInfoForYear = salesRepository.GetMonthlySalesDataForAYear(id);
            //monthlyInfoForYear = salesRepository.GetMonthlySalesDataForAYear(year);

            List<BarChartModel> chart = new List<BarChartModel>();

            string[] months = { "Jan", "Feb", "March", "April", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };

            int i;
            int count = monthlyInfoForYear.Count();

            //Adding All the Months and Giving the Sum Amount Zero to the chart
            for (i = 0; i < 12; i++)
            {
                BarChartModel barChartModel = new BarChartModel(months[i], 0);
                chart.Add(barChartModel);
            }

            //Now Assigning Value to the months where the Sum Amount exists for that particular month
            for (i = 0; i < count; i++)
            {
                chart[monthlyInfoForYear[i].Id - 1].Y = monthlyInfoForYear[i].Column1;
            }

            ViewBag.DataPoints = Newtonsoft.Json.JsonConvert.SerializeObject(chart);
            return View();
        }
    }
}