using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class27
    {
        static void Main(string[] strings)
        {
            int health = 4;
            int maxHealth = 10;

            while (true)
            {
                DrawBar(health, maxHealth, ConsoleColor.Red);

                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Введите число, на котором измениться жизнь");
                health += Convert.ToInt32(Console.ReadLine());

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void DrawBar(int value, int maxValue, ConsoleColor color, char symbol = '#')
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
            Console.Write(bar + ']');
        }
    }
}
