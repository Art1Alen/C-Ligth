using System;

namespace CSLight
{
    internal class Class11
    {
        static void Main()
        {
            const string Setconsolecolor = "1";
            const string Exit = "2";
            const string Clear = "3";

            const string SetconsolecolorRed = "1";
            const string SetconsolecolorYello = "2";
            const string SetconsolecolorBlue = "3";

            bool isExitApp = true;

            while (isExitApp)
            {
                Console.WriteLine("Введите имя пользователя?");
                string userName = Console.ReadLine();

                Console.WriteLine("Установите пароль?");
                string password = Console.ReadLine();

                Console.WriteLine($"Доступные команды: " +
                    $"\n {Setconsolecolor} setconsolecolor - Меняет цвет фона консоли. " +                 
                    $"\n {Exit} exit - завершение работы приложения. " +
                    $"\n {Clear} clear - очистить консоль.");

                Console.Write("Введите команду: ");
                string enterCommand = Console.ReadLine();

                switch (enterCommand)
                {
                    case Setconsolecolor:

                        Console.WriteLine($"Выбирите цвет: \n {SetconsolecolorRed} Red \n {SetconsolecolorYello} Yello \n {SetconsolecolorBlue} Blue");
                        string color = Console.ReadLine();

                        switch (color)
                        {
                            case SetconsolecolorRed:
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.Clear();
                                break;
                            case SetconsolecolorYello:
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.Clear();
                                break;
                            case SetconsolecolorBlue:
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Цвет не найден.");
                                break;
                        }
                        break;                                         

                    case Exit:

                        exitApp = false;

                        break;

                    case Clear:

                        Console.Clear();

                        break;                                                                    
                }
            }
        }
    }
}