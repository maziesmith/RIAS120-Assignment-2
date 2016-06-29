using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.Model
{
    public class Physician:Person
    {
        public string Speciality { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
