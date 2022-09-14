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
            int rublesToDollar = 30;
            int rublesToEuro = 35;

            int dollarToRubles = 25;
            int dollarToEuro = 20;

            int euroToRubles = 40;
            int euroToDollar = 45;
           
            float currencyCount;

            Console.WriteLine("СберБанк обмен валютами\n");          
            Console.WriteLine("Введите баланс Рублей");
            float currencyRubles = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Введите баланс Доллара");
            float currencyDollar = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Введите баланс Евро");
            float currencyEuro = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Введите 1 для обмена Рубл на Доллар");
            Console.WriteLine("Введите 2 для обмена Рубл на Евро");
            Console.WriteLine("Введите 3 для обмена Доллар на Рубл");
            Console.WriteLine("Введите 4 для обмена Доллар на Евро");
            Console.WriteLine("Введите 5 для обмена Евро на Доллар");
            Console.WriteLine("Введите 6 для обмена Евро на Рубл");
            string userInput = Console.ReadLine();                      

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Сколько вы хотите обменять?");
                    currencyCount = Convert.ToSingle(Console.ReadLine());
                    if(currencyRubles >= currencyCount)
                    {
                        currencyRubles -= currencyCount;
                        currencyRubles += currencyCount / rublesToDollar;
                    }
                    else
                    {
                        Console.WriteLine("Недопустимая сумма");
                    }
                    break;

                case "2":
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

                case "3":
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

                case "4":
                    Console.WriteLine("Сколько вы хотите обменять?");
                    currencyCount = Convert.ToSingle(Console.ReadLine());
                    if (currencyDollar >= currencyCount)
                    {
                        currencyDollar -= currencyCount;
                        currencyDollar += currencyCount / dollarToEuro;
                    }
                    else
                    {
                        Console.WriteLine("Недопустимая сумма");
                    }
                    break;
                case "5":
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
                case "6":
                    Console.WriteLine("Сколько вы хотите обменять?");
                    currencyCount = Convert.ToSingle(Console.ReadLine());
                    if (currencyEuro >= currencyCount)
                    {
                        currencyEuro -= currencyCount;
                        currencyEuro += currencyCount / euroToDollar;
                    }
                    else
                    {
                        Console.WriteLine("Недопустимая сумма");
                    }
                    break;
            }
            Console.WriteLine($"Ваш баланс {currencyRubles} рублей {currencyDollar} долларов {currencyEuro} евро");

        }
    }
}
