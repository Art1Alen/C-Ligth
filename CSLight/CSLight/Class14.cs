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
            Random random = new Random();

            int maxNumber = 27;
            int minNumber = 1;
            int numberN = 3;

            for (int i = minNumber; i < maxNumber; i += numberN)
            {
                Console.WriteLine(random.Next(minNumber, maxNumber));
            }
        }
    }
}
