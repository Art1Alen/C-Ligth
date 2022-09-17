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

            float rublesToDollar = 25f;
            float rublesToEuro = 45f;

            float dollarToRubles = 65f;
            float dollarToEuro = 20f;

            float euroToRubles = 85f;
            float euroToDollar = 40f;

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

                    Console.WriteLine("Выберите на что хотите обменять");
                    Console.WriteLine($"Введите {ExchangeRubles} для обмена в Доллар");
                    Console.WriteLine($"Введите {ExchangeEuro} для обмена в Евро");

                    string rubleExchange = Console.ReadLine();

                    switch (rubleExchange)
                    {
                        case ExchangeRubles:

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

                        case ExchangeEuro:

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
                    Console.WriteLine($"Введите {ExchangeDollar} для обмена в Рубл");
                    Console.WriteLine($"Введите {ExchangeEuro} для обмена в Евро");

                    string dollarExchange = Console.ReadLine();

                    switch (dollarExchange)
                    {
                        case ExchangeDollar:

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

                        case ExchangeEuro:

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

                    Console.WriteLine("Выберите на что хотите обменять");
                    Console.WriteLine($"Введите {ExchangeRubles} для обмена в Рубл");
                    Console.WriteLine($"Введите {ExchangeDollar} для обмена в Доллар");

                    string euroExchange = Console.ReadLine();

                    switch (euroExchange)
                    {
                        case ExchangeRubles:

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

                        case ExchangeDollar:

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
