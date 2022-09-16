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
            const string ExchangeRubles = "1";
            const string ExchangeDollar = "2";
            const string ExchangeEuro = "3";
            const string ExitBank = "4";

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

            Console.WriteLine($"Введите {ExchangeRubles} для обмена Рубл");
            Console.WriteLine($"Введите {ExchangeDollar} для обмена Доллар");
            Console.WriteLine($"Введите {ExchangeEuro} для обмена Евро");
            Console.WriteLine($"Введите {ExitBank} для выхода из банка");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case ExchangeRubles:

                    const string ExchangeRublesToDollar = "1";
                    const string ExchangeRublesToEuro = "2";

                    Console.WriteLine("Выберите на что хотите обменять");
                    Console.WriteLine($"Введите {ExchangeRublesToDollar} для обмена Доллар");
                    Console.WriteLine($"Введите {ExchangeRublesToEuro} для обмена Евро");

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

                    const string ExchangeDollarToRubles = "1";
                    const string ExchangeDollarToEuro = "2";

                    Console.WriteLine("Выберите на что хотите обменять");
                    Console.WriteLine($"Введите {ExchangeDollarToRubles} для обмена Рубл");
                    Console.WriteLine($"Введите {ExchangeDollarToEuro} для обмена Евро");

                    string dollarExchange = Console.ReadLine();

                    switch (dollarExchange)
                    {
                        case ExchangeDollarToRubles:

                            Console.WriteLine("Сколько вы хотите обменять?");
                            currencyCount = Convert.ToSingle(Console.ReadLine());

                            if (currencyDollar >= currencyCount)
                            {
                                currencyDollar -= currencyCount;
                                currencyDollar += currencyCount * dollarToRubles;
                            }
                            else
                            {
                                Console.WriteLine("Недопустимая сумма");
                            }
                            break;

                        case ExchangeDollarToEuro:

                            Console.WriteLine("Сколько вы хотите обменять?");
                            currencyCount = Convert.ToSingle(Console.ReadLine());

                            if (currencyDollar >= currencyCount)
                            {
                                currencyDollar -= currencyCount;
                                currencyDollar += currencyCount * dollarToEuro;
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

                    const string ExchangeEuroToRubles = "1";
                    const string ExchangeEuroToDollar = "2";

                    Console.WriteLine("Выберите на что хотите обменять");
                    Console.WriteLine($"Введите {ExchangeEuroToRubles} для обмена Рубл");
                    Console.WriteLine($"Введите {ExchangeEuroToDollar} для обмена Доллар");

                    string euroExchange = Console.ReadLine();

                    switch (euroExchange)
                    {
                        case ExchangeEuroToRubles:

                            Console.WriteLine("Сколько вы хотите обменять?");
                            currencyCount = Convert.ToSingle(Console.ReadLine());

                            if (currencyEuro >= currencyCount)
                            {
                                currencyEuro -= currencyCount;
                                currencyEuro += currencyCount * euroToRubles;
                            }
                            else
                            {
                                Console.WriteLine("Недопустимая сумма");
                            }
                            break;

                        case ExchangeEuroToDollar:

                            Console.WriteLine("Сколько вы хотите обменять?");
                            currencyCount = Convert.ToSingle(Console.ReadLine());

                            if (currencyEuro >= currencyCount)
                            {
                                currencyEuro -= currencyCount;
                                currencyEuro += currencyCount * euroToDollar;
                            }
                            else
                            {
                                Console.WriteLine("Недопустимая сумма");
                            }
                            break;
                    }
                    Console.WriteLine($"Ваш баланс {currencyRubles} рублей {currencyDollar} долларов {currencyEuro} евро");
                    break;

                case ExitBank:

                    Console.WriteLine("Выход из банка");

                    break;
            }
        }
    }
}
