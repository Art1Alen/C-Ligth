using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ling
{
    internal class Class2
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                Hospital hospital = new Hospital();
                hospital.Work();
            }
        }

        class Hospital
        {
            private List<Patient> _patients;

            public Hospital()
            {
                _patients = new List<Patient>();
                _patients.Add(new Patient("Иванов Иван Иванович", 20, "Нагноение раны"));
                _patients.Add(new Patient("Чистяков Иван Юрьевич", 25, "Переломы ребер"));
                _patients.Add(new Patient("Ковалев Марк Елисеевич", 30, "Чахотка"));
                _patients.Add(new Patient("Мельников Даниил Владиславович", 22, "Чахотка"));
                _patients.Add(new Patient("Трофимов Сергей Иванович", 35, "Глухонемота"));
                _patients.Add(new Patient("Быков Егор Захарович", 44, "Побои"));
                _patients.Add(new Patient("Горбачев Егор Макарович", 21, "Синяки"));
                _patients.Add(new Patient("Колесников Илья Иванович", 24, "Головная боль"));
                _patients.Add(new Patient("Фокин Артур Андреевич", 27, "Головная боль"));
                _patients.Add(new Patient("Антонов Али Григорьевич", 28, "Побои"));
            }

            public void Work()
            {
                const string CommandSortByFullName = "1";
                const string CommandSortByAge = "2";
                const string CommandShowByDisease = "3";
                const string CommandExit = "4";
                bool isWork = true;

                while (isWork)
                {
                    Console.WriteLine($"Добро пожаловать в больницу" +
                        $"\n{CommandSortByFullName}. - отсортировать всех больных по ФИО" +
                        $"\n{CommandSortByAge}. - отсортировать всех больных по возрасту" +
                        $"\n{CommandShowByDisease} - вывести больных с определенными заболеваниями" +
                        $"\n{CommandExit} - выход.");
      
                    string userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case CommandSortByFullName:
                            SortPatientsByFullName();
                            break;

                        case CommandSortByAge:
                            SortPatientsByAge();
                            break;

                        case CommandShowByDisease:
                            ShowPatientsByDisease();
                            break;

                        case CommandExit:
                            isWork = false;
                            break;

                        default:
                            Console.WriteLine("Хм.. Такой команды нету.");
                            break;
                    }
                }

                    Console.Clear();
            }

            private void SortPatientsByFullName()
            {
                _patients = _patients.OrderBy(patient => patient.FullName).ToList();
                ShowPatientsInfo(_patients);
            }

            private void SortPatientsByAge()
            {
                _patients = _patients.OrderBy(patient => patient.Age).ToList();
                ShowPatientsInfo(_patients);
            }

            private void ShowPatientsByDisease()
            {
                Console.Write("Введите заболевание: ");
                string disease = Console.ReadLine();
                _patients = _patients.Where(patient => patient.Disease.ToLower() == disease.ToLower()).ToList();
                ShowPatientsInfo(_patients);
            }

            private void ShowPatientsInfo(List<Patient> patients)
            {
                for (int i = 0; i < patients.Count; i++)
                {
                    Console.Write($"{i + 1}. ");
                    patients[i].ShowPatient();
                }
            }
        }

        class Patient
        {
            public Patient(string fullName, int age, string disease)
            {
                FullName = fullName;
                Age = age;
                Disease = disease;
            }

            public string FullName { get; private set; }
            public int Age { get; private set; }
            public string Disease { get; private set; }

            public void ShowPatient()
            {
                Console.WriteLine($"ФИО: {FullName}. Возраст: {Age}. Заболевание: {Disease}.");
            }
        }
    }
}
