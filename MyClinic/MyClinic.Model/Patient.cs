using System.Collections.Generic;

namespace MyClinic.Model
{
    public class Patient : Person
    {
        public Diagnosis Diagnosis { get; set; }
        //public Physician Physician { get; set; }
        public List<Prescription> Prescriptions { get; set; }
    }
}