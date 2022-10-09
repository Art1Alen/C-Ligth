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

            int[] array = new int[0];

            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine($"Введите число или команду ({CommandSum} - сложить числа, {CommandExit} - выход):");

                string inputUser = Console.ReadLine().ToLower();

                switch (inputUser)
                {
                    case CommandSum:

                        int sum = 0;

                        for (int i = 0; i < array.Length; i++)
                        {
                            sum += array[i];
                        }

                        Console.WriteLine($"Сумма чисел: {sum}");
                        Console.ReadLine();

                        break;

                    case CommandExit:

                        isWorking = false;

                        break;
                         
                }
            }
        }
    }
}
