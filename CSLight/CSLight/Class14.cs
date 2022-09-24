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

            int numberN = random.Next(minNumber, maxNumber);
         

            for (int i = minNumber; numberN < maxNumber; numberN++)
            {

                Console.WriteLine(numberN);
            }
        }
    }
}
