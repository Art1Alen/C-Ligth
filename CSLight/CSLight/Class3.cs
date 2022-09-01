using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    class Class3
    {
        static void Main(string[] strg)
        {
            string name = "Пунтин";
            string surname = "Владимир";
            string temporaryVariable = name;
            name = surname;
            surname = temporaryVariable;

            Console.WriteLine($"Ваша Имя \n{name} {surname}");
            Console.ReadKey();
        }
    }
}
