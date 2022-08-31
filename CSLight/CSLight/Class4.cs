using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class4
    {
        static void Main(string[] strg)
        {
            int money;
            int crystalCounts;
            int crystalPrice = 10;

            Console.WriteLine("Сколько у вас золото?");
            money = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Сколько кристаллов хотите купить?\n Цена {crystalPrice}");
            Console.WriteLine("Сколько вам нужно?");
            crystalCounts = Convert.ToInt32(Console.ReadLine());

            money -= crystalCounts * crystalPrice;

            Console.WriteLine($"У вас в сумке {crystalCounts} кристалов и {money} денег");

        }
    }
}
