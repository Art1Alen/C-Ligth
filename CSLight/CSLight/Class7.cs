using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class7
    {
        static void Main()
        {
            string appExit = "exit";

            while (appExit == null)
            {
                Console.WriteLine("Для выхода из приложение Введите exit");
                Console.WriteLine("Как дела?");

                appExit = Console.ReadLine();

                Console.Clear();

                if (appExit == "exit")
                {
                    Console.WriteLine("Выход из приложение");
                }
            }
        }
    }
}
