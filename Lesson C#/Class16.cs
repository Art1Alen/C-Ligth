using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class16
    {
        static void Main()
        {
            int symbol = 0;
            int count = 0;
            int result = 0;

            char symbolOne = '(';
            char symbolTwo = ')';

            Console.WriteLine($"Введите строку из символо '{symbolOne}' и '{symbolTwo}' ");
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == symbolOne)
                {
                    symbol++;
                }

                else if (text[i] == symbolTwo)
                {
                    if (i != text.Length - 1 && text[i + 1] != symbolOne)
                    {
                        count++;
                    }
                    symbol--;
                }

                if (symbol < 0)
                {
                    break;
                }

                if (symbol == 0)
                {
                    result = count;
                }
            }

            if (symbol == 0)
            {
                Console.WriteLine("Строка корректная " + text + "\n" + "Максимум глубина равняется: " + (result + 1));
            }

            else
            {
                Console.WriteLine("Ошибка! Не верная строка " + text);
            }
        }
    }
}
