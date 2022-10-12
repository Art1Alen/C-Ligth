using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class21
    {
        static void Main()
        {
            const string CommandSum = "sum";
            const string CommandExit = "exit";

            bool isWorking = true;

            int lengthArray = 0;
            int arraySum = 0;

            int[] array = new int[lengthArray];
            int[] arrayCopy = new int[lengthArray];

            while (isWorking)
            {
                Console.WriteLine($"Введите число,{CommandExit} или {CommandSum}");
                string message = Console.ReadLine().ToLower();

                if (message != "sum" && message != "exit")
                {
                    int userInput = Convert.ToInt32(message);

                    lengthArray += 1;
                    array = new int[lengthArray];

                    for (int i = 0; i < arrayCopy.Length; i++)
                    {
                        array[i] = arrayCopy[i];
                    }

                    array[lengthArray - 1] = userInput;
                    arrayCopy = new int[lengthArray];

                    arrayCopy[lengthArray - 1] = userInput;
                }

                else if (message == "sum")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        arraySum += array[i];
                    }

                    Console.WriteLine($"Сумма массива: {arraySum} ");
                    arraySum = 0;
                }


                else if (message == "exit")
                {
                    isWorking = false;
                }
                else
                {
                    Console.WriteLine($"Нет такой команды ");
                }
            }
        }
    }
}