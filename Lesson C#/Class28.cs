using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class28
    {
        static void Main()
        {
            string userInput;

            MessageOutput("Привет Введите любое число");

            int conversion;

            userInput = Console.ReadLine();

            bool result = int.TryParse(userInput, out conversion);

            if (result)
            {
                MessageOutput($"Преобразование прошло успешно. Число: {conversion}");
            }
            else
            {
                MessageOutput("Преобразование завершилось неудачно");

            }
        }

        static void MessageOutput(string text)
        {
            Console.WriteLine(text);
            Console.ReadKey();
            Console.Clear();
        }
    }
}


