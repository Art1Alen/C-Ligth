using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class19
    {
        static void Main()
        {
            const int minNumberArray = 1;
            const int maxNumberArray = 10;

            Random random = new Random();

            int[,] array = new int[10, 10];

            int max = 0;
            int nullNumber = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(minNumberArray, maxNumberArray);

                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                    }

                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == max)
                    {
                        array[i, j] = nullNumber;
                    }

                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Маскимальное Число {max}");
            Console.ReadKey();
        }
    }
}

