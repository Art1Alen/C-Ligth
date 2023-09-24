using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class13
    {
        static void Main()
        {
            int tryCount = 3; 

            string password = "msi-123";       

            for (int i = 0; i < tryCount; i++)
            {
                Console.WriteLine("Введите пароль от MSI" );
                string userInput = Console.ReadLine();

                if(userInput == password)
                {
                    Console.WriteLine("Секрет Конпании MSI ваших руках");
                    break;
                }
                else
                {
                    Console.WriteLine($" У вас Осталось {tryCount - i - 1} Попыток");
                }
            }
        }
    }
}
