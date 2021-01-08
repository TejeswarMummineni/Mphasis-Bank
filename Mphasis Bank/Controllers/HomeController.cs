using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mphasis_Bank.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Registration r)
        {
            if (ModelState.IsValid)
            {
                ob.Registrations.Add(r);
                int rows = ob.SaveChanges();
                if (rows > 0)
                {

                    ViewData["a"] = "User created Successfully!!";

                }
                else
                {
                    ViewData["a"] = "Error Occured";
                }
            }
            else
            {
                return View();
            }

            return View();
        }
    }
}