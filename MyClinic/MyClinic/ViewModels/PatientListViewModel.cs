using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyClinic.Model;

namespace MyClinic.ViewModels
{
    public class PatientListViewModel
    {
        public List<Patient> Patients { get; set; }
    }
}