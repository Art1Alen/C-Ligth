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

            int minNumberArray = 10;
            int maxNumberArray = 26;

            int maxNumber = 0;
            int line = 0;
            int column = 0;

            for (int d = 0; d < array.GetLength(1); d++)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (d == 0)
                        {
                            array[i, j] = random.Next(minNumberArray, maxNumberArray);
                        }

                        if (array[i, j] > maxNumber)
                        {
                            maxNumber = array[i, j];
                            line = i;
                            column = j;
                        }

                        Console.Write(array[i, j] + " ");
                    }

                    Console.WriteLine(" ");
                }

                if (d == 0)
                {
                    array[line, column] = 0;
                    Console.WriteLine($"\nСтрока {line}. Столбец {column}.\n");
                }
           
                Console.ReadKey();
            }
        }
    }
}
