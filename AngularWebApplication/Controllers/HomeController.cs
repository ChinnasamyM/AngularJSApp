using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Web.Script.Serialization;

namespace AngularWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string Get()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Age");
            dt.Columns.Add("Country");
            dt.Columns.Add("Year");
            dt.Columns.Add("Date");            
            DataRow dr;
            for (int i=0; i<50;i++){
                dr = dt.NewRow();
                dr[0]="Name "+i.ToString();
                dr[1] = (10+i).ToString();
                dr[2] = "Country " +i.ToString();
                dr[3] = (2000 + i).ToString();
                dr[4] = DateTime.UtcNow.ToString();
                dt.Rows.Add(dr);                
            }
            string str= DataTableToJsonWithJavaScriptSerializer(dt);
            return str;
        }

        public string DataTableToJsonWithJavaScriptSerializer(DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }

    }
}