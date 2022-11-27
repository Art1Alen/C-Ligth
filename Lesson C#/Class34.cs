using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class34
    {
        const string CommandAddDossier = "1";
        const string CommandShowDossier = "2";
        const string CommandDeleteDossier = "3";
        const string CommandExit = "4";
        static void Main()
        {
            Dictionary<string, string> dossier = new Dictionary<string, string>();

            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"Меню программы:\n{CommandAddDossier} - Добавить новое досье\n{CommandShowDossier} - Показать все досье\n{CommandDeleteDossier} - Удалить досье\n{CommandExit} - Выход из программы");
                Console.Write("\nВведите Номер пукта: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddDossier:
                        AddDossier(dossier);
                        break;
                    case CommandShowDossier:
                        ShowDossiers(dossier);
                        break;
                    case CommandDeleteDossier:
                        DeleteDossier(dossier, userInput);
                        break;
                    case CommandExit:
                        Console.WriteLine("Для выхода нажмите Enter");

                        isWork = false;
                        break;
                }
            }
        }

        static void AddDossier(Dictionary<string, string> dossier, bool isAddDossier = false)
        {
            Console.WriteLine("Введите ФИО");
            string name = Console.ReadLine();

            if (dossier.ContainsKey(name) == isAddDossier)
            {
                Console.WriteLine("Введите дольжность");
                string jobTitle = Console.ReadLine();

                dossier.Add(name, jobTitle);
            }
            else
            {
                Console.WriteLine("Что-то пошло не так либо данные уже сушествуют Повторим Операции?");
            }

        }

        static void ShowDossiers(Dictionary<string, string> dossier)
        {
            foreach (var item in dossier)
            {
                Console.WriteLine($"ФИО - {item.Key}:  Должность - {item.Value}");
            }

            Console.ReadKey();
        }

        static void DeleteDossier(Dictionary<string, string> dossier, string name)
        {
            Console.WriteLine("Введите данные ФИО чтобы удалить");
            name = Console.ReadLine();

            if (dossier.ContainsKey(name))
            {
                dossier.Remove(name);
            }
            else
            {
                Console.WriteLine("Что-тоо пошло не так Повторим операцию?");
            }

            Console.WriteLine("Данные Удалены");
            Console.ReadKey();
        }
    }
}
