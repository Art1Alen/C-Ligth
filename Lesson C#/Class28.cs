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
            NumberConversion();
        }

        static void MessageOutput(string text)
        {
            Console.WriteLine(text);
            Console.ReadKey();
            Console.Clear();
        }

        static int NumberConversion()
        {
            bool isWorking = true;
            int result = 0;

            while (isWorking)
            {
                MessageOutput("Введите число");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out result))
                {
                    MessageOutput($"Число {result}, сконвертировано");
                    isWorking = false;
                }
                else
                {
                    MessageOutput($"{userInput} не может быть сконвертировано");
                }
            }
            return result;
        }
    }
}


