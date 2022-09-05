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
            int timerTicking = 1;

            bool isExit;

            if (isExit = true)
            {
                Console.WriteLine("Для выхода из таймера Введите exit");

                for (int i = 0; i < timerTicking; i++)
                {
                    Console.WriteLine($"{timerTicking++}");                   
                    string textExit = Console.ReadLine();
                    Console.ReadLine();

                    if (textExit == "exit")
                    {
                        isExit = false;
                        break;
                    }
                }
            }
        }
    }
}
