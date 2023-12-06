using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CreateInstance.Factory;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CreateInstance.Controllers
{
    [Route("[controller]")]
    public class Test : Controller
    {
        private IDependencyReflectorFactory dependencyReflectorFactory;
        private readonly IServiceProvider serviceProvider;
        public Test(IDependencyReflectorFactory dependencyReflectorFactory, IServiceProvider serviceProvider)
        {
            this.dependencyReflectorFactory = dependencyReflectorFactory;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet("test")]
        public async Task<object> test()
        {
            object[] constructorRequiredParamertersNULL = null;

            // var nesne1 = dependencyReflectorFactory.GetReflectedType<Sinif>(typeof(Sinif), constructorRequiredParamertersNULL);
            string FirstName = "firstName";
            string LastName = "lastName";
            DateTime BirthDate = new DateTime(2000, 11, 29);
            string Email = "farketmez";

            object[] constructorRequiredParamerters = { FirstName, LastName, BirthDate, Email };

            var nesne1 = Activator.CreateInstance(typeof(Person), constructorRequiredParamerters);
            // var nesne2 = Activator.CreateInstance(typeof(Customer), constructorRequiredParamerters);
            // var nesne3 = ActivatorUtilities.CreateInstance(serviceProvider, typeof(Customer), constructorRequiredParamerters);
            // var nesne4 = ActivatorUtilities.CreateInstance(serviceProvider, typeof(Person), constructorRequiredParamerters);

            try
            {
                Customer nesne5 = dependencyReflectorFactory.Getinstance<Customer>(typeof(Customer), constructorRequiredParamerters);// Constructor içinde DI var
                var nesne6 = dependencyReflectorFactory.Getinstance<Person>(typeof(Person), constructorRequiredParamerters); //DI yok
                var nesne7 = dependencyReflectorFactory.Getinstance<Sinif>(typeof(Sinif), constructorRequiredParamertersNULL);// Constructor tanımlı değil
            }
            catch (Exception ex)
            {
                Console.WriteLine("İlgili sınfın Constructur methodu yok");
            }
            return Ok();

        }
    }
}