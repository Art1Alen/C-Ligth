using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class32
    {
        static void Main()
        {          
                StoreQueue();                     
        }

        static void StoreQueue()
        {
            Random random = new Random();

            Queue<int> buyers = new Queue<int>();

            int maxNumber = 100;
            int minNumber = 25;
            int cashAmount = 0;

            bool isExit = false;

            buyers.Enqueue(random.Next(minNumber, maxNumber));
            buyers.Enqueue(random.Next(minNumber, maxNumber));
            buyers.Enqueue(random.Next(minNumber, maxNumber));
            buyers.Enqueue(random.Next(minNumber, maxNumber));

            do
            {
                foreach (var buyer in buyers)
                {
                    Console.WriteLine(buyer);
                }

                Console.WriteLine($"на Кассе денег {cashAmount += buyers.Peek()}");
                Console.WriteLine($"На кассе {buyers.Dequeue()}");

                Console.ReadKey();
                Console.Clear();

            }while (isExit);                                   
        }
    }
}
