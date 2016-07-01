using System;
using System.Collections.Generic;
using MyClinic.Model;
using System.Linq;

namespace MyClinic.Service
{
    public class PhysicianService
    {
        public IList<Physician> GetPhysicians()
        {
            return FakeRepository.Physicians;
        }

        public Physician GetPhysician(string physicianUserName)
        {
            return FakeRepository.Physicians
                .FirstOrDefault(p => string.Equals(p.UserName, physicianUserName, StringComparison.OrdinalIgnoreCase));
        }

        public Physician GetPhysician(int id)
        {
            return FakeRepository.Physicians.FirstOrDefault(p => p.ID == id);
        }
    }
}
