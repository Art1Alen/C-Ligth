using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class25
    {
        static void Main()
        {
            int[] array = new int[5] { 1, 2, 3, 4, 5 };               

            Console.Write("Дан массив чисел: ");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.Write("\nНасколько позиций сдвинуть массив влево? Укажите число: ");
            int inputUser = Convert.ToInt32(Console.ReadLine());

            int shift = inputUser % array.Length;

            for (int i = 0; i < shift; i++)
            {
                Console.Clear();
                Console.Write("Измененный массив: ");

                int tempNumber = array[0];

                for (int j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];

                    Console.Write(array[j] + " ");
                }

                array[array.Length - 1] = tempNumber;

                Console.Write(array[array.Length - 1]);
                Console.ReadKey();
            }
        }
    }
}
