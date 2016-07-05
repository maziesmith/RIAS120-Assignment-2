using System;
using System.Web.Mvc;
using MyClinic.Service;
using MyClinic.ViewModels;

namespace MyClinic.Controllers
{
    public class HomeController : Controller
    {
        PatientService PatientSvc;
        PhysicianService physicianSvc;

        public HomeController()
        {
            PatientSvc = new PatientService();
            physicianSvc = new PhysicianService();
        }

        public ActionResult Index()
        {
            var vm = new HomeViewModel();
            vm.Physicians = physicianSvc.GetPhysicians();
            vm.NumberOfPatients = PatientSvc.GetNumberOfPatients();
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Physician(int id)
        {
            var physician = physicianSvc.GetPhysician(id);
            return View(physician);
        }
    }
}