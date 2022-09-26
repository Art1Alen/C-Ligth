using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class15
    {
        static void Main()
        {
            Random random = new Random();

            int result = random.Next(0,100);
            int doble = 2;
      

            if (result >= 0)
            {
                while (result != 0 && result != 1)
                {
                    result /= doble;
                   Console.WriteLine(result);
                }
            }


         
        }
    }
}
