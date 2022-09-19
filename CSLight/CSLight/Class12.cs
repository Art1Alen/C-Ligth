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
            string lateral = "";        

            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            Console.WriteLine($"Имя:  {name},длина имени: {name.Length}");

            Console.Write("Введите символ: ");
            string simbol = Console.ReadLine();

            int additionToLength = 4;
            string emptySpaceForSecondLine = " ";

            Console.WriteLine($"Cимвол:  {simbol}");
            Console.Clear();
            Console.WriteLine("Ответь");

            for (int i = 1; i <= (name.Length + additionToLength); i += 1)
            {
                lateral += simbol;
            }

            Console.WriteLine(lateral);
            Console.WriteLine(lateral[0] + emptySpaceForSecondLine + name + emptySpaceForSecondLine + lateral[lateral.Length - 1]);
            Console.WriteLine(lateral);
        }
    }
}
