﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class7
    {
        static void Main()
        {
            bool appState = true;

            while (appState)
            {
                Console.WriteLine("Для выхода из приложение Введите exit");
                Console.WriteLine("Как дела?");

                string appExit = Console.ReadLine();

                Console.Clear();

                if (appExit == "exit")
                {
                    appState = false;
                }
            }
        }
    }
}