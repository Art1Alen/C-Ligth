using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class14
    {
        static void Main()
        {
            int maxNumber = 27;
            int minNumber = 1;
            int number = 10;

            for (int i = minNumber; i <= maxNumber; i++)
            {
                for (int j = minNumber; j < number; j++)
                {
                    for (int k = 0; k < number; k++)
                    {
                        for (int l = 0; l < number; l++)
                        {
                            if (j + k + l == i)
                            {
                                Console.WriteLine($" {i} || {j}{k}{l}");
                            }
                        }
                    }
                }
            }
        }
    }
}
