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

            string initialArray = " ";
            string localMaximaArray = " ";
            string doubleQuotes = " ";

            int minNumber = 1;
            int maxNumber = 10;

            int[] array = new int[30];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i] = random.Next(minNumber, maxNumber);

                initialArray += Convert.ToString(array[i] + doubleQuotes);

                for (int k = 1; k < array.GetLength(0) - 1; k++)
                {
                    if (array[k] > array[k + 1])
                    {
                        localMaximaArray = array[k] + doubleQuotes;
                    }
                }

                Console.Clear();
                Console.WriteLine($"\nВесть список массива {initialArray}");
                Console.WriteLine($"Локальные максимумы: {localMaximaArray}");
            }
        }
    }
}

