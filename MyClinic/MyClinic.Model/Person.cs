using System;

namespace MyClinic.Model
{
    public abstract class Person
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Dob { get; set; }
    }

    public enum Gender
    {
        female,
        male
    }
}
