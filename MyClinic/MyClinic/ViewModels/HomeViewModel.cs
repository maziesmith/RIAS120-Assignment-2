using System.Collections.Generic;
using MyClinic.Model;

namespace MyClinic.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Physician> Physicians { get; set; }
        public int NumberOfPatients { get; set; }
    }
}