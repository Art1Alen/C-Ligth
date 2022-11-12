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
            GetNumber();
        }

        static void OutputMessage(string text)
        {
            Console.WriteLine(text);
            Console.ReadKey();
            Console.Clear();
        }

        static int GetNumber()
        {
            bool isWorking = true;
            int result = 0;

            while (isWorking)
            {
                OutputMessage("Введите число");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out result))
                {
                    OutputMessage($"Число {result}, сконвертировано");
                    isWorking = false;
                }
                else
                {
                    OutputMessage($"{userInput} не может быть сконвертировано");
                }
            }
            return result;
        }
    }
}


