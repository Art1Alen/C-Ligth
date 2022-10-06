using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class20
    {
        static void Main()
        {
            Random random = new Random();

            string initialArray = "";
            string localMaximaArray = "";
            string doubleQuotes = " ";

            int minNumber = 1;
            int maxNumber = 10;

            int plusOneNumber = 1;

            int takeAwayOne = 1;
            int takeAwayTwo = 2;

            int[] array = new int[30];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i] = random.Next(minNumber, maxNumber);

                initialArray += Convert.ToString(array[i] + doubleQuotes);

                if ((i == array.GetLength(0) - takeAwayOne) && (array[0] > array[1]))
                {
                    localMaximaArray += array[0] + doubleQuotes;
                }

                if (i == array.GetLength(0) - takeAwayOne)
                {

                    for (int k = 1; k < array.GetLength(0) - takeAwayOne; k++)
                    {

                        if (array[k] > array[k + plusOneNumber] && array[k] > array[k - takeAwayOne])
                        {
                            localMaximaArray += array[k] + doubleQuotes;
                        }
                    }
                }

                if ((i == array.GetLength(0) - takeAwayOne) && (array[array.GetLength(0) - takeAwayOne] > array[array.GetLength(0) - takeAwayTwo]))
                {
                    localMaximaArray += doubleQuotes + array[array.GetLength(0) - takeAwayOne];
                }
            }

            Console.WriteLine($"\nВесть список массива {initialArray}");

            Console.WriteLine($"Локальные максимумы: {localMaximaArray}");
        }
    }
}

