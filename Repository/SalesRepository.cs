using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PcHut.Controllers;
using PcHut.Models;

namespace PcHut.Repository
{
    public class SalesRepository
    {
        private pchutEntities2 context = new pchutEntities2();

        public List<SumGroupByModel> GetYearlySalesData()
        {
            List<SumGroupByModel> yearlySalesReport = context.Database.SqlQuery<SumGroupByModel>("select sum(total_ammount) as Column1, YEAR(date) as Id from invoice group by YEAR(Date)").ToList();
            return yearlySalesReport;
        }

        public List<SumGroupByModel> GetMonthlySalesDataForAYear(int year)
        {
            List<SumGroupByModel> monthlyInfoByForYear = context.Database.SqlQuery<SumGroupByModel>("select sum(total_ammount) as Column1, Month(Date) as Id from invoice where YEAR(date) = "+year+" group by MONTH(Date)").ToList();

            return monthlyInfoByForYear;
        }
    }
}