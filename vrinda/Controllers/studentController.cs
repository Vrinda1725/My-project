
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using vrinda.Models;

namespace vrinda.Controllers
{
    public class studentController : Controller
    {
        public static List<student> studentlist = new List<student>
        {
             new student{ Id=0, username="payal", password="p1" },
               new student { Id=1, username="nancy", password="n2"},
               new student { Id=2, username="vaishali", password="v3" },
               new student {  Id=3, username="muskan", password="m4" },
               new student {  Id=3, username="saumya", password="s5" },

        };
        
        // GET: student
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Index2()
        {
            return View(studentlist);
        }


        [HttpPost]
        public ActionResult Index(student obj)
        {
            string user = obj.username;
            string pass = obj.password;
            if (user == "usera" && pass == "passa")
            {
                return RedirectToAction("Index2", studentlist);
            }
            else
            {
                return Content("login failed");
            }

        }
        [HttpGet]
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(student per)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("create", per);
                }
                studentlist.Add(per);
                return RedirectToAction("Index2");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult details(int id)
        {
            student per = studentlist.Find(emp => emp.Id == id);
            return View(per);
        }

        [HttpGet]
        public ActionResult edit(int id)
        {
            student per = studentlist.Find(emp => emp.Id == id);
            return View(per);
        }

        [HttpPost]
        public ActionResult edit(int id, student std)
        {
            student per = studentlist.Find(emp => emp.Id == id);
            studentlist.Remove(per);
            studentlist.Add(std);
            return RedirectToAction("Index2");
        }

        [HttpGet]
        public ActionResult delete(int id)
        {
            student per = studentlist.Find(emp => emp.Id == id);
            return View(per);
        }

        [HttpPost]
        public ActionResult delete(int id, student std)
        {
            student per = studentlist.Find(emp => emp.Id == id);
            studentlist.Remove(per);
            return RedirectToAction("Index2");
        }


        public ActionResult logout()
        {
            return RedirectToAction("Index");
        }
        
    }
}
