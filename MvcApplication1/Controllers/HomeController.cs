using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        demoEntites dc = new demoEntites();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string Index(string name, string dob, string desi, string qua, string rad, string drp, string relo, string mob, string em)
        {
            employee e = new employee();
            e.name = name;
            e.dob = DateTime.Parse(dob);
            e.desi = desi;
            e.qua = qua;
            // e.sex = rad;
            e.sex = rad;
            e.isrelo = relo;
            e.cntid = drp;
            e.email = em;
            e.mob = mob;
            dc.employees.Add(e);
            dc.SaveChanges();
            return "CREATED";
        }
        public JsonResult getdata()
        {
            //var data = from n in dc.emps
            //           select new { n.id, n.name, n.dob, n.desi, n.qua, n.sex, n.isrelo, n.cntid, n.email, n.mob };


            return Json(dc.employees.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult editdata(int id)
        {
            var data = from n in dc.employees where n.id == id select n;

            return Json(data.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string edit(int empid, string name, string dob, string desi, string qua, string rad, string drp, string relo, string mob, string em)
        {
            var query = from n in dc.employees where n.id == empid select n;

            foreach (var item in query)
            {
                item.name = name;
                item.dob = DateTime.Parse(dob);
                item.desi = desi;
                item.qua = qua;
                item.sex = rad;
                item.cntid = drp;
                item.email = em;
                item.isrelo = relo;
                item.mob = mob;
            }
            dc.SaveChanges();
            return "Your data is updated now !!!";
        }
        public ActionResult del(int id)
        {
            employee emp = dc.employees.Find(id);
            dc.employees.Remove(emp);
            dc.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
