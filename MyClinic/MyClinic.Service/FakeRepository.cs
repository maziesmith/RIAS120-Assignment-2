using System;
using System.Collections.Generic;
using MyClinic.Model;

namespace MyClinic.Service
{
    internal static class FakeRepository
    {
        public static List<Diagnosis> Diagnoses { get; set; }
        public static List<Patient> Patients { get; set; }
        public static List<Physician> Physicians { get; set; }
        public static List<Prescription> Prescriptions { get; set; }

        static FakeRepository()
        {
            Initialize();
        }

        private static void Initialize()
        {
            #region Diagnoses

            var diabetes1 = new Diagnosis { ID = 1, Name = "Type 1 diabetes mellitus", Code = "E10" };
            var diabetes2 = new Diagnosis { ID = 2, Name = "Type 2 diabetes mellitus", Code = "E11" };
            var thyrotoxicosis = new Diagnosis { ID = 3, Name = "Thyrotoxicosis [hyperthyroidism]", Code = "E05" };
            var thyroiditis = new Diagnosis { ID = 4, Name = "Thyroiditis", Code = "E06" };

            #endregion

            #region Patients

            var patient1 = new Patient { ID = 1001, Diagnosis = diabetes1, FullName = "John Smith", UserName = "jsmith", Gender = Gender.male, Dob = new DateTime(1990, 1, 1) };
            var patient2 = new Patient { ID = 1002, Diagnosis = diabetes2, FullName = "John Doe", UserName = "jdoe", Gender = Gender.male, Dob = new DateTime(1970, 1, 1) };
            var patient3 = new Patient { ID = 1003, Diagnosis = thyrotoxicosis, FullName = "Mary Williams", Gender = Gender.female, Dob = new DateTime(1960, 1, 1) };
            var patient4 = new Patient { ID = 1004, Diagnosis = thyroiditis, FullName = "Sarah Brown", Gender = Gender.female, Dob = new DateTime(1950, 1, 1) };
            var patient5 = new Patient { ID = 1005, Diagnosis = diabetes2, FullName = "Joe Johnson", Gender = Gender.male, Dob = new DateTime(1950, 1, 1) };
            var patient6 = new Patient { ID = 1006, Diagnosis = diabetes2, FullName = "Dan Daniels", Gender = Gender.male, Dob = new DateTime(1950, 1, 1) };
            var patient7 = new Patient { ID = 1007, Diagnosis = diabetes2, FullName = "Annie Dork", Gender = Gender.female, Dob = new DateTime(1950, 1, 1) };
            var patient8 = new Patient { ID = 1008, Diagnosis = thyrotoxicosis, FullName = "Liz Black", Gender = Gender.female, Dob = new DateTime(1960, 1, 1) };

            #endregion

            #region Physicians

            var physician1 = new Physician { ID = 101, FullName = "James Jones", Speciality = "Internal Medicine", UserName = "jjones", Dob = new DateTime(1950, 1, 1), Gender = Gender.male };
            var physician2 = new Physician { ID = 102, FullName = "Linda Miller", Speciality = "Endocrinologist", UserName = "lmiller", Dob = new DateTime(1950, 1, 1), Gender = Gender.female };

            #endregion

            #region Prescriptions

            var prescription1 = new Prescription { ID = 10001, Note = "Amp. insulin X  #10" };
            var prescription2 = new Prescription { ID = 10002, Note = "Tab Metformin 500 mg  #200" };
            var prescription3 = new Prescription { ID = 10003, Note = "Tab Methimazole 5 mg  #30" };
            var prescription4 = new Prescription { ID = 10004, Note = "Tab Prednisolone   #25" };
            var prescription5 = new Prescription { ID = 10005, Note = "Tab Metformin 500 mg  #50" };
            var prescription6 = new Prescription { ID = 10006, Note = "Tab Metformin 500 mg  #60" };
            var prescription7a = new Prescription { ID = 10007, Note = "Tab Metformin 500 mg  #70" };
            var prescription7b = new Prescription { ID = 10007, Note = "Amp. insulin X  #90" };
            var prescription8 = new Prescription { ID = 10003, Note = "Tab Methimazole 5 mg  #80" };

            #endregion

            #region Mix

            //patient1.Physician = physician1;
            //patient2.Physician = physician1;
            //patient3.Physician = physician2;
            //patient4.Physician = physician2;
            //patient5.Physician = physician1;
            //patient6.Physician = physician1;
            //patient7.Physician = physician1;
            //patient8.Physician = physician2;

            patient1.Prescriptions = new List<Prescription> { prescription1 };
            patient2.Prescriptions = new List<Prescription> { prescription2 };
            patient3.Prescriptions = new List<Prescription> { prescription3 };
            patient4.Prescriptions = new List<Prescription> { prescription4 };
            patient5.Prescriptions = new List<Prescription> { prescription5 };
            patient6.Prescriptions = new List<Prescription> { prescription6 };
            patient7.Prescriptions = new List<Prescription> { prescription7a, prescription7b };
            patient8.Prescriptions = new List<Prescription> { prescription8 };

            physician1.Patients = new List<Patient> { patient1, patient2, patient5, patient6, patient7 };
            physician2.Patients = new List<Patient> { patient3, patient4, patient8 };

            #endregion


            Diagnoses = new List<Diagnosis> { diabetes1, diabetes2, thyrotoxicosis, thyroiditis };
            Patients = new List<Patient> { patient1, patient2, patient3, patient4, patient5, patient6, patient7, patient8 };
            Physicians = new List<Physician> { physician1, physician2 };
            Prescriptions = new List<Prescription> { prescription1, prescription2, prescription3, prescription4, prescription5, prescription6, prescription7a, prescription7b, prescription8 };
        }
    }
}
