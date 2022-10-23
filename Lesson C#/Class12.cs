using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class12
    {
        static void Main()
        {
            string lateral = " ";

            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            Console.WriteLine($"Имя:  {name},длина имени: {name.Length}");

            Console.Write("Введите символ: ");
            string simbol = Console.ReadLine();

            int emptySpaceForSecondLine = 2;

            Console.WriteLine($"Cимвол:  {simbol}");
            Console.Clear();
            Console.WriteLine("Ответь");

            for (int i = 1; i <= (name.Length + emptySpaceForSecondLine + emptySpaceForSecondLine); i += 1)
            {
                lateral += simbol;
            }

            Console.WriteLine(lateral);
            Console.WriteLine(simbol + " " + name + " " + simbol);
            Console.WriteLine(lateral);
        }
    }
}
