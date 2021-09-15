using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PcHut.Models;
using PcHut.Repository;

namespace PcHut.Controllers
{
    public class Sales_RecordController : Controller
    {
        Sales_RecordRepository sales_RecordRepository = new Sales_RecordRepository();
        // GET: Sales_Record
        public ActionResult Index()
        {
            sales_record sales_Record = new sales_record();
            List<Item> items = (List<Item>)Session["Cart"];
            for(int i = 0; i < items.Count; i++)
            {
                sales_Record.user_id = (int)Session["user_id"];
                sales_Record.date = DateTime.Now;
                sales_Record.product_id = items[i].Products.product_id;
                sales_Record.quantity = items[i].Quantity;
                sales_Record.price = items[i].Products.price;
                this.sales_RecordRepository.Insert(sales_Record);
            }
            return View();
        }
    }
}