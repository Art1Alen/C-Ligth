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
            int minutesOfWaiting = 60;

            int hourExpectation;
            int minutEexpectation;

            Console.WriteLine("Добро пожаловать в Поликлинике");
            Console.WriteLine("Введите количество людей в очереди");

            grandmothers = Convert.ToInt32(Console.ReadLine());

            timeOfReceipt += grandmothers * timeOfReceipt - timeOfReceipt;
            hourExpectation = timeOfReceipt / minutesOfWaiting;
            minutEexpectation = timeOfReceipt % minutesOfWaiting;

            Console.WriteLine($"Вы должны отстоять в очереди {hourExpectation} час и {minutEexpectation} минут");
        }
    }
}
