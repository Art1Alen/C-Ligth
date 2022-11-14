﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class30
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5 };

            Shuffle(array);            
        }

        static void Shuffle(int[] array)
        {
            Random random = new Random();

            for (int i = array.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);

                int temp = array[j];
                array[j] = array[i];
                array[i] = temp;
                Console.WriteLine(temp);
            }
        }
    }
}