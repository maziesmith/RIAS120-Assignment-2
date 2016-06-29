using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClinic.Service;
using MyClinic.ViewModels;

namespace MyClinic.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        PatientService PatientSvc;
        PhysicianService physicianSvc;

        public PatientController()
        {
            PatientSvc = new PatientService();
            physicianSvc = new PhysicianService();
        }

        [Authorize(Roles = "physician")]
        public ActionResult Index()
        {
            var vm = new PatientListViewModel();

            var physician = physicianSvc.GetPhysician(User.Identity.Name);

            if (physician != null)
            {
                vm.Patients = physician.Patients;
            }

            return View(vm);
        }

        [Authorize(Roles = "patient")]
        public ActionResult Me()
        {
            var vm = new PatientListViewModel();

            var patient = PatientSvc.GetPatientByUserName(User.Identity.Name);

            if (patient == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("File", new { id = patient.ID });
        }

        [Authorize(Roles = "physician,patient")]
        public ActionResult File(int id)
        {
            var vm = new PatientFileVeiwModel();

            vm.Patient = PatientSvc.GetPatient(id);

            return View(vm);
        }
    }
}