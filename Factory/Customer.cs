using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInstance.Factory
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public required string Email { get; set; }

        private readonly ITest _test;
        public Customer(ITest _test,string firstName, string lastName, DateTime birthDate, string email)
        {
            this._test=_test;
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
            _test.yazdir();
        }
    }
}