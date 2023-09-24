using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class35
    {
        static void Main(string[] args)
        {
            List<int> numders = new List<int>();

            int[] arrayOne = { 1, 2, 1 };
            int[] arrayTwo = { 3, 2 };

            string spase = " ";

            AddUniqueValue(numders, arrayOne);
            AddUniqueValue(numders, arrayTwo);

            for (int i = 0; i < numders.Count; i++)
            {
                Console.Write($"{numders[i]} {spase}");
            }
        }

        static void AddUniqueValue(List<int> numders, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (numders.Contains(array[i]) == false)
                {
                    numders.Add(array[i]);
                }
            }
        }
    }
}
