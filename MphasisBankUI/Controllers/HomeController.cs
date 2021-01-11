using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using Bussiness_Entities;
using Blogic;


namespace MphasisBankUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        EmployeeBL eb = new EmployeeBL();
        CustomerBL cb = new CustomerBL();
        TranscationBL ts = new TranscationBL();
        // GET: Employee
        public ActionResult Home()
        {
            return View(); 
        }
        public ActionResult Open()
        {
            return RedirectToAction("EmployeeUI");
        }
        public ActionResult Close()
        {
            return RedirectToAction("DeActivateCustomer");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginEntites log)
        {
            
            LoginBL lb = new LoginBL();
            int res = lb.Loginvalidate(log);
            if (res==1)
            {
                Session["user"] = log.Username;
                Session["master"] = "EmployeeView";
                return View("Login", "EmployeeView");
                
            }
            else if (res == 2)
            {
                Session["user"] = log.Username;
                Session["master"] = "CustomerView";
                return View("Login", "CustomerView");
                
            }
            else if (res == 3)
            {
                Session["user"] = log.Username;
                Session["master"] = "ManagerView";
                return View("Login", "ManagerView");
                
            }
            else
            {
                ViewData["err"] = "Access Denied!! invalid credentials";
                return View();
            }
           
        }

        public ActionResult EmployeeUI()
        {
            if (Session["user"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public ActionResult EmployeeUI(string pan)
        {

            if (Session["user"] != null)
            {
                int res1 = eb.ValidatePanCus(pan);
                int res2 = eb.ValidatePanEmp(pan);
                if (res1 > 0)
                {
                    ViewData["a"] = "Customer already exist";
                }
                else if (res2 > 0)
                {
                    ViewData["a"] = "Employee Cannot be Customer";
                }

                else
                {
                    return RedirectToAction("AddCustomer");
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }
        public ActionResult AddCustomer()
        {
            if (Session["user"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        [HttpPost]
        public ActionResult AddCustomer(CustomerEntities ce)
        {
            if (Session["user"] != null)
            {
                CustomerBL cb = new CustomerBL();
              int res=cb.AddCustomer(ce);

                if (res > 0)
                {
                    Response.Redirect("EmployeeUI");

                }
                else
                {
                    ViewData["a"] = "Invalid Details";
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }
       
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(EmployeeEntites ce)
        {
            if (Session["user"] != null)
            {
                if (ModelState.IsValid)
                {

                    EmployeeBL eb = new EmployeeBL();
                    CustomEntities ob = eb.AddEmployee(ce);

                }
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ViewResult AddTranscation()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddTranscation(TranscationEnties te)
        {
            if (Session["user"] != null)
            {
                TranscationBL tb = new TranscationBL();
                int res = tb.AddTranscation(te);

                if (res > 0)
                {
                    ViewData["a"] = "Transcation Success full";

                }
                else
                {
                    ViewData["a"] = "Inavalid Transcation";
                }

                return View();
            }
            else
            {
                return View();
            }
        }
    
        public ViewResult ViewTrans(string Aid ,int?page)
        {
           
                    TranscationBL tb = new TranscationBL();
                    var res = tb.ViewTrans(Aid);
                    return View(res.ToList().ToPagedList(page ?? 1, 3));
                
            
        }
        public ActionResult DeActivateCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeActivateCustomer(String custid)
        {
            if (Session["user"] != null)
            {
                string Custid = custid;
                int res = eb.DeActivateCustomer(Custid);
                if (res > 0)
                {
                    ViewData["msg"] = "DeActivated Customer Sucessfully";
                }
                else
                {
                    ViewData["msg"] = "Please Check CustomerId";
                }


                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult LoanAc()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoanAc(Loan_Account_Entites le)
        {
            if (Session["user"] != null)
            {
                LoanBL lb = new LoanBL();
                int res = lb.LoanAc(le);
                if (res > 0)
                {
                    ViewData["a"] = "Your Loan Sucessfull";

                }
                else
                {
                    ViewData["a"] = "INValid CustomerDetails";
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult LoanTrans()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoanTrans(Loan_Transcation_Entites le)
        {

            if (Session["user"] != null)
            {
                LoanBL lb = new LoanBL();
                int res = lb.LoanTrans(le);
                if (res > 0)
                {
                    ViewData["a"] = "Paid Emi Sucessfull";

                }
                else
                {
                    ViewData["a"] = "INValid CustomerDetails";
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Login");
        }
    }
}