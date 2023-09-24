namespace CSLight
{
    internal class Class27
    {
        static void Main(string[] strings)
        {
            const string ExitApp = "exit";

            int health = 5;
            int maxHealth = 10;

            bool isOpenApp = true;

            Console.WriteLine($"\nДля Выхода введите {ExitApp}\nДля продолжение нажмите Enter");

            string inputUser = Console.ReadLine().ToLower();
            Console.Clear();

            if (inputUser == ExitApp)
            {
                isOpenApp = false;
            }
            else
            {
                while (isOpenApp)
                {
                    CreateBar(health, maxHealth, ConsoleColor.Red);

                    Console.SetCursorPosition(0, 5);

                    Console.WriteLine("Введите число для изменение полоски жизньи");

                    health += Convert.ToInt32(Console.ReadLine());

                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void CreateBar(int value, int maxValue, ConsoleColor color, char symbol = '#')
        {
            ConsoleColor defaultColor = Console.BackgroundColor;

            string bar = "";

            for (int i = 0; i < value; i++)
            {
                bar += symbol;
            }

            Console.SetCursorPosition(0, 0);
            Console.Write('[');
            Console.BackgroundColor = color;
            Console.Write($"{bar}");
            Console.BackgroundColor = defaultColor;

            bar = "_";

            for (int i = value; i < maxValue; i++)
            {
                bar += "_";
            }

            Console.Write($"{bar}]");
        }
    }
}
