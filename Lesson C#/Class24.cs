using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class24
    {
        static void Main()
        {
            string text = "Я Поворь иду на Работу Готовить";
            string[] cook = text.Split(' ');

            for (int i = 0; i < cook.Length; i++)
            {
                Console.Write(cook[i] + "\n");
            }

            Console.ReadKey();
        }
    }
}
