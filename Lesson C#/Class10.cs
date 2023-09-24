//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CSLight
//{
//    internal class Class10
//    {
//        static void Main()
//        {
//            const string ExchangeRubles = "1";
//            const string ExchangeDollar = "2";
//            const string ExchangeEuro = "3";
//            const string CommandExit = "Exit";

//            float rublesToDollar = 1 / 60f;
//            float rublesToEuro = 1 / 61f;

//            float dollarToRubles = 60f;
//            float dollarToEuro = 1f;

//            float euroToRubles = 61f;
//            float euroToDollar = 1f;

//            float currencyCount;

//            Console.WriteLine("СберБанк обмен валютами\n");
//            Console.WriteLine("Введите баланс Рублей");
//            float currencyRubles = Convert.ToSingle(Console.ReadLine());
//            Console.WriteLine("Введите баланс Доллара");
//            float currencyDollar = Convert.ToSingle(Console.ReadLine());
//            Console.WriteLine("Введите баланс Евро");
//            float currencyEuro = Convert.ToSingle(Console.ReadLine());

//            while (CommandExit == "Exit")
//            {
//                Console.WriteLine($"Введите {ExchangeRubles} для обмена Рубл");
//                Console.WriteLine($"Введите {ExchangeDollar} для обмена Доллар");
//                Console.WriteLine($"Введите {ExchangeEuro} для обмена Евро");
//                Console.WriteLine($"Для выхода программы Введите {CommandExit}");
//                string userInput = Console.ReadLine();

//                switch (userInput)
//                {
//                    case ExchangeRubles:

//                        Console.WriteLine("Выберите на что хотите обменять");
//                        Console.WriteLine($"Введите {ExchangeDollar} для обмена в Доллар");
//                        Console.WriteLine($"Введите {ExchangeEuro} для обмена в Евро");

//                        string rubleExchange = Console.ReadLine();


//                        switch (rubleExchange)
//                        {
//                            case ExchangeDollar:

//                                Console.WriteLine("Сколько вы хотите обменять?");
//                                currencyCount = Convert.ToSingle(Console.ReadLine());

//                                if (currencyRubles >= currencyCount)
//                                {
//                                    currencyRubles -= currencyCount;
//                                    currencyDollar += currencyCount * rublesToDollar;
//                                }
//                                else
//                                {
//                                    Console.WriteLine("Недопустимая сумма");
//                                }
//                                break;

//                            case ExchangeEuro:

//                                Console.WriteLine("Сколько вы хотите обменять?");
//                                currencyCount = Convert.ToSingle(Console.ReadLine());

//                                if (currencyRubles >= currencyCount)
//                                {
//                                    currencyRubles -= currencyCount;
//                                    currencyEuro += currencyCount * rublesToEuro;
//                                }
//                                else
//                                {
//                                    Console.WriteLine("Недопустимая сумма");
//                                }
//                                break;
//                        }
//                        Console.WriteLine($"Ваш баланс {currencyRubles} рублей {currencyDollar} долларов {currencyEuro} евро");
//                        break;

//                    case ExchangeDollar:

//                        Console.WriteLine("Выберите на что хотите обменять");
//                        Console.WriteLine($"Введите {ExchangeRubles} для обмена в Рубл");
//                        Console.WriteLine($"Введите {ExchangeEuro} для обмена в Евро");

//                        string dollarExchange = Console.ReadLine();

//                        switch (dollarExchange)
//                        {
//                            case ExchangeRubles:

//                                Console.WriteLine("Сколько вы хотите обменять?");
//                                currencyCount = Convert.ToSingle(Console.ReadLine());

//                                if (currencyDollar >= currencyCount)
//                                {
//                                    currencyDollar -= currencyCount;
//                                    currencyRubles += currencyCount * dollarToRubles;
//                                }
//                                else
//                                {
//                                    Console.WriteLine("Недопустимая сумма");
//                                }
//                                break;

//                            case ExchangeEuro:

//                                Console.WriteLine("Сколько вы хотите обменять?");
//                                currencyCount = Convert.ToSingle(Console.ReadLine());

//                                if (currencyDollar >= currencyCount)
//                                {
//                                    currencyDollar -= currencyCount;
//                                    currencyEuro += currencyCount * dollarToEuro;
//                                }
//                                else
//                                {
//                                    Console.WriteLine("Недопустимая сумма");
//                                }
//                                break;
//                        }
//                        Console.WriteLine($"Ваш баланс {currencyRubles} рублей {currencyDollar} долларов {currencyEuro} евро");
//                        break;

//                    case ExchangeEuro:

//                        Console.WriteLine("Выберите на что хотите обменять");
//                        Console.WriteLine($"Введите {ExchangeRubles} для обмена в Рубл");
//                        Console.WriteLine($"Введите {ExchangeDollar} для обмена в Доллар");

//                        string euroExchange = Console.ReadLine();

//                        switch (euroExchange)
//                        {
//                            case ExchangeRubles:

//                                Console.WriteLine("Сколько вы хотите обменять?");
//                                currencyCount = Convert.ToSingle(Console.ReadLine());

//                                if (currencyEuro >= currencyCount)
//                                {
//                                    currencyEuro -= currencyCount;
//                                    currencyRubles += currencyCount * euroToRubles;
//                                }
//                                else
//                                {
//                                    Console.WriteLine("Недопустимая сумма");
//                                }
//                                break;

//                            case ExchangeDollar:

//                                Console.WriteLine("Сколько вы хотите обменять?");
//                                currencyCount = Convert.ToSingle(Console.ReadLine());

//                                if (currencyEuro >= currencyCount)
//                                {
//                                    currencyEuro -= currencyCount;
//                                    currencyDollar += currencyCount * euroToDollar;
//                                }
//                                else
//                                {
//                                    Console.WriteLine("Недопустимая сумма");
//                                }
//                                break;
//                        }

//                        Console.WriteLine($"Ваш баланс {currencyRubles} рублей {currencyDollar} долларов {currencyEuro} евро");

//                        break;
//                }
//            }
//        }
//    }
//}
