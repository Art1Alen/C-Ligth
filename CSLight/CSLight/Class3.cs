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
            string name1;
            string surname1;

            name1 = surname;
            surname1 = name;


            Console.WriteLine($"Ваша Имя {name1} {surname1}");
            Console.ReadKey();
        }
    }
}
