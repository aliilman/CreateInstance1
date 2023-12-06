using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInstance.Factory
{
    public class Test : ITest
    {
        public void yazdir()
        {
            System.Console.WriteLine("Test içim DI");
        }
    }
}