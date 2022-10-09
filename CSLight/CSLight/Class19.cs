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
            Random random = new Random();

            int[,] array = new int[10, 10];

            int minNumberArray = 0;
            int maxNumberArray = 10;

            int nullNumber = 0;
            int line;
            int column;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(minNumberArray, maxNumberArray);

                    if (array[i, j] > nullNumber)
                    {
                        nullNumber += array[i, j];
                    }

                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine(" ");
            }

            array[line = nullNumber, column = nullNumber] = nullNumber;
            Console.WriteLine($"\nСтрока {line}. Столбец {column}.\n");

            Console.ReadKey();
        }
    }
}
