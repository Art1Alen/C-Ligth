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
            string name = "Владимир";
            string surname = "Пунтин";

            Console.WriteLine($"Ваша Имя {name} {surname} Верно?");
            Console.WriteLine("Если не верно то ведите новое Имя");
            Console.ReadKey();
            Console.WriteLine("Как вас завут?");
            name = Console.ReadLine();
            Console.WriteLine("Ваша фамилия?");
            surname = Console.ReadLine();
            Console.WriteLine($"Ваша Имя {name} {surname} Верно?");
            Console.ReadKey();



        }
    }
}
