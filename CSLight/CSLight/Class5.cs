using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    class Class5
    {
        static void Main(string[] strg)
        {
            int grandmothers;

            int timeOfReceipt = 10;
            int hour;
            int minute;

            Console.WriteLine("Добро пожаловать в Поликлинике");
            Console.WriteLine("Введите количество людей в очереди");

            grandmothers = Convert.ToInt32(Console.ReadLine());

            timeOfReceipt += grandmothers * 10 - 10;
            hour = timeOfReceipt / 60;
            minute = timeOfReceipt % 60;

            Console.WriteLine($"Вы должны отстоять в очереди {hour} час и {minute} минут");
        }
    }
}
