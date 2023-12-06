using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInstance.Factory
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public required string Email { get; set; }

        public Person(string firstName, string lastName, DateTime birthDate, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
        }

        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - BirthDate.Year;

                if (DateTime.Now < BirthDate.AddYears(age))
                {
                    age--;
                }
                return age;
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Ad: {FirstName} {LastName}");
            Console.WriteLine($"Doğum Tarihi: {BirthDate.ToShortDateString()}");
            Console.WriteLine($"Yaş: {Age}");
            Console.WriteLine($"E-posta: {Email}");
        }
    }
}