﻿namespace CSLight
{
    internal class Class20
    {
        static void Main()
        {
            Random random = new Random();

            string spaces = " ";
            string localMaximaArray = " ";
            string doubleQuotes = " ";

            int minNumber = 1;
            int maxNumber = 10;

            int[] array = new int[30];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i] = random.Next(minNumber, maxNumber);

                spaces += Convert.ToString(array[i] + " ");

                if (i == array.GetLength(0) - 1)
                {
                    for (int k = 1; k < array.GetLength(0) - 1; k++)
                    {

                        if (array[k] > array[k + 1] && array[k] > array[k - 1])
                        {
                            localMaximaArray += array[k] + " ";
                        }
                    }
                }

                if ((i == array.GetLength(0) - 1) && (array[0] > array[1]))
                {
                    localMaximaArray += array[0] + " ";
                }

                if ((i == array.GetLength(0) - 1) && (array[array.GetLength(0) - 1] > array[array.GetLength(0) - 2]))
                {
                    localMaximaArray += "" + array[array.GetLength(0) - 1];
                }
            }

            Console.WriteLine($"Исходный массив{spaces}");
            Console.WriteLine($"Локальные максимумы: {localMaximaArray}");
        }
    }
}

