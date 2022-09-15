using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class10
    {
        static void Main()
        {
            float rublesToDollar = 30;
            float rublesToEuro = 35;

            float dollarToRubles = 25;
            float dollarToEuro = 20;

            float euroToRubles = 40;
            float euroToDollar = 45;

            float currencyCount;

            Console.WriteLine("СберБанк обмен валютами\n");
            Console.WriteLine("Введите баланс Рублей");
            float currencyRubles = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Введите баланс Доллара");
            float currencyDollar = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Введите баланс Евро");
            float currencyEuro = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Введите 1 для обмена Рубл");
            Console.WriteLine("Введите 2 для обмена Доллар");
            Console.WriteLine("Введите 3 для обмена Евро");
            Console.WriteLine("Введите 7 для выхода из банка");

            const string ExchangeRubles = "1";
            const string ExchangeDollar = "2";
            const string ExchangeEuro = "3";

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case ExchangeRubles:
                    Console.WriteLine("Выберите на что хотите обменять");
                    Console.WriteLine("Введите 1 для обмена Доллар");
                    Console.WriteLine("Введите 2 для обмена Евро");

                    const string ExchangeRublesToDollar = "1";
                    const string ExchangeRublesToEuro = "2";

                    string rubleExchange = Console.ReadLine();

                    switch (rubleExchange)
                    {
                        case ExchangeRublesToDollar:
                            Console.WriteLine("Сколько вы хотите обменять?");
                            currencyCount = Convert.ToSingle(Console.ReadLine());

                            if (currencyRubles >= currencyCount)
                            {
                                currencyRubles -= currencyCount;
                                currencyRubles += currencyCount * rublesToDollar;
                            }
                            else
                            {
                                Console.WriteLine("Недопустимая сумма");
                            }
                            break;

                        case ExchangeRublesToEuro:
                            Console.WriteLine("Сколько вы хотите обменять?");
                            currencyCount = Convert.ToSingle(Console.ReadLine());

                            if (currencyRubles >= currencyCount)
                            {
                                currencyRubles -= currencyCount;
                                currencyRubles += currencyCount * rublesToEuro;
                            }
                            else
                            {
                                Console.WriteLine("Недопустимая сумма");
                            }
                            break;
                    }
                    Console.WriteLine($"Ваш баланс {currencyRubles} рублей {currencyDollar} долларов {currencyEuro} евро");
                    break;

                case ExchangeDollar:
                    Console.WriteLine("Выберите на что хотите обменять");
                    Console.WriteLine("Введите 1 для обмена Рубл");
                    Console.WriteLine("Введите 2 для обмена Евро");

                    const string ExchangeDollarToRubles = "1";
                    const string ExchangeDollarToEuro = "2";

                    string dollarExchange = Console.ReadLine();

                    switch (dollarExchange)
                    {
                        case ExchangeDollarToRubles:
                            Console.WriteLine("Сколько вы хотите обменять?");
                            currencyCount = Convert.ToSingle(Console.ReadLine());

                            if (currencyRubles >= currencyCount)
                            {
                                currencyRubles -= currencyCount;
                                currencyRubles += currencyCount * dollarToRubles;
                            }
                            else
                            {
                                Console.WriteLine("Недопустимая сумма");
                            }
                            break;

                        case ExchangeDollarToEuro:
                            Console.WriteLine("Сколько вы хотите обменять?");
                            currencyCount = Convert.ToSingle(Console.ReadLine());

                            if (currencyRubles >= currencyCount)
                            {
                                currencyRubles -= currencyCount;
                                currencyRubles += currencyCount * dollarToEuro;
                            }
                            else
                            {
                                Console.WriteLine("Недопустимая сумма");
                            }
                            break;
                    }
                    Console.WriteLine($"Ваш баланс {currencyRubles} рублей {currencyDollar} долларов {currencyEuro} евро");
                    break;
                case ExchangeEuro:
                    Console.WriteLine("Выберите на что хотите обменять");
                    Console.WriteLine("Введите 1 для обмена Рубл");
                    Console.WriteLine("Введите 2 для обмена Доллар");

                    const string ExchangeEuroToRubles = "1";
                    const string ExchangeEuroToDollar = "2";

                    string euroExchange = Console.ReadLine();

                    switch (euroExchange)
                    {
                        case ExchangeEuroToRubles:
                            Console.WriteLine("Сколько вы хотите обменять?");
                            currencyCount = Convert.ToSingle(Console.ReadLine());

                            if (currencyRubles >= currencyCount)
                            {
                                currencyRubles -= currencyCount;
                                currencyRubles += currencyCount * euroToRubles;
                            }
                            else
                            {
                                Console.WriteLine("Недопустимая сумма");
                            }
                            break;

                        case ExchangeEuroToDollar:
                            Console.WriteLine("Сколько вы хотите обменять?");
                            currencyCount = Convert.ToSingle(Console.ReadLine());

                            if (currencyRubles >= currencyCount)
                            {
                                currencyRubles -= currencyCount;
                                currencyRubles += currencyCount * euroToDollar;
                            }
                            else
                            {
                                Console.WriteLine("Недопустимая сумма");
                            }
                            break;
                    }
                    Console.WriteLine($"Ваш баланс {currencyRubles} рублей {currencyDollar} долларов {currencyEuro} евро");
                    break;
            }
        }
    }
}
