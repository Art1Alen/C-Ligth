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

            int result = random.Next(1, 27);
            int result1 = random.Next(1, result);

            Console.WriteLine($"{result1} {result}");
        }
    }
}
