using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MyClinic.Service;
using MyClinic.ViewModels;

namespace MyClinic.Controllers
{
    public class AccountController : Controller
    {
        PatientService PatientSvc;
        PhysicianService physicianSvc;

        public AccountController()
        {
            PatientSvc = new PatientService();
            physicianSvc = new PhysicianService();
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if(!System.Web.Security.FormsAuthentication.Authenticate(model.UserName, model.Password))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }

            var roleList = new List<string>();
            var physician = physicianSvc.GetPhysician(model.UserName);
            if (physician != null) { roleList.Add("physician"); }
            var patient = PatientSvc.GetPatientByUserName(model.UserName);
            if (patient != null) { roleList.Add("patient"); }
            string roles = string.Join(",", roleList);

            var authTicket = new System.Web.Security.FormsAuthenticationTicket(
              1,
              model.UserName,  //user id
              DateTime.Now,
              DateTime.Now.AddMinutes(System.Web.Security.FormsAuthentication.Timeout.Minutes),
              model.RememberMe,
              roles,
              "/");

            HttpCookie cookie = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName,
                                               System.Web.Security.FormsAuthentication.Encrypt(authTicket));

            Response.Cookies.Add(cookie);
            return RedirectToLocal(returnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}