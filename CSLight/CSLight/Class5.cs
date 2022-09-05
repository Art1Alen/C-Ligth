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
            int timeOfReceipt = 10;
            int minutesInHour = 60;

            Console.WriteLine("Добро пожаловать в Поликлинике");
            Console.WriteLine("Введите количество людей в очереди");

            int grandmothers = Convert.ToInt32(Console.ReadLine());

            int serviceTime = timeOfReceipt * grandmothers;
            int hourExpectation = serviceTime / minutesInHour;
            int minutEexpectation = serviceTime % minutesInHour;

            Console.WriteLine($"Вы должны отстоять в очереди {hourExpectation} час и {minutEexpectation} минут");
        }
    }
}
