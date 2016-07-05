using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClinic.Service;
using MyClinic.ViewModels;

namespace MyClinic.Controllers
{
    [Authorize, RequireHttps]
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

            var patient = PatientSvc.GetPatient(id);

            if (patient == null)
            {
                throw new HttpException(404, "File not found!");
            }

            // Check permission for patients.
            // A patient can see only his or her profile, not anybody else.
            if (User.IsInRole("patient"))
            {
                if (!string.Equals(patient.UserName, User.Identity.Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new HttpException(403, "Access denied!");
                }
            }

            // Check permission for physicians.
            // A physician can see only his or her patients profile, but not other physicians' patients.
            if (User.IsInRole("physician"))
            {
                var physician = physicianSvc.GetPhysician(User.Identity.Name);
                var accessToPatient = physician.Patients.Any(p => p.ID == id);

                if (!accessToPatient)
                {
                    throw new HttpException(403, "Access denied!");
                }
            }

            vm.Patient = patient;
            return View(vm);
        }
    }
}