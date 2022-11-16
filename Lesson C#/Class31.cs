using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class31
    {
        static void Main()
        {
            Console.WriteLine("Добро пожаловать Гильдию Знаниею. Здесь вы можете узновать тайные знание древних свитков из Аниме");
            Console.WriteLine("Введите ключевое слово. Например Танзиро");

            string userInput = Console.ReadLine();

            Library(userInput);
        }

        static void Library(string userInput)
        {
            Dictionary<string, string> library = new Dictionary<string, string>();

            library.Add("Танзиро", "Убица Деманов");
            library.Add("Саске", "Он из клана Учиха");
            library.Add("Мидория", "Ученик Всемогушего и наследник один за всех");
            library.Add("Леви", "Чел с коротким ростом");
            library.Add("Сайтама", "Лысый но туповатый чел приятный для обшение");
            library.Add("Нацу", "Убица драконов Огненый волшебник");
            library.Add("Луффи", "Резиновый чел соломеном шляпе");
            library.Add("Наруто", "Седьмой хокаге");
            library.Add("Йо", "Шаман из Рода Асакура");
            library.Add("Ичиго", "Временный шинигами");
            library.Add("Альфонс", "Чел в Доспехе но где его тело?");
            library.Add("Гон", "Охотник бешенной силой");
            library.Add("Макима", "Ээ хз кто она");
            library.Add("Римуро", "Слись который нагнул весь игровой мир");

            if (library.ContainsKey(userInput))
            {
                Console.WriteLine(library[userInput]);
            }
            else
            {
              Console.WriteLine("Что то пошло не так");
            }
        }
    }
}
