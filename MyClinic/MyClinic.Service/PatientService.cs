using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinic.Model;

namespace MyClinic.Service
{
    public class PatientService
    {
        public int GetNumberOfPatients()
        {
            return FakeRepository.Patients.Count;
        }

        public Patient GetPatientByUserName(string userName)
        {
            return FakeRepository.Patients
                .FirstOrDefault(p => string.Equals(p.UserName, userName, StringComparison.OrdinalIgnoreCase));
        }

        public Patient GetPatient(int id)
        {
            return FakeRepository.Patients.FirstOrDefault(p => p.ID == id);
        }
    }
}
