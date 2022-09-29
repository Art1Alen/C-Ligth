using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class17
    {
        static void Main()
        {
            const string Rashamon = "2";
            const string Huganzakura = "4";
            const string DimensionalRift = "3";
            const string Fireball = "1";

            Random random = new Random();

            bool IsEnableGame = true;
            bool IsDimensionalRift = false;

            string enterSpell;

            int healthBoss = random.Next(80, 100);
            int armorBoss = random.Next(20, 80);
            int damageBoss = random.Next(30,50);
            int healthShadowMage = random.Next(250, 400);
            int armorShadowMage = random.Next(20, 50);
            int manaPlayer = random.Next(100, 400);

            Console.WriteLine($"Маг: здоровье:{healthShadowMage}, броня:{armorShadowMage}, урон:{manaPlayer}.");
            Console.WriteLine($"Босс: здоровье:{healthBoss}, броня:{armorBoss}, урон:{damageBoss}.");
            Console.Write("\nБитва началась! ");

            Console.WriteLine($"Передвами стоит огромный огр он настроен агресивно избежать драки не возможно приготовтесь к бою. \n Ваши доступные заклинания:" +

                $"\n {Fireball} - Огненый шар наносит 50 урона, отнимает 30 едениц маны." +
                $"\n {Rashamon} - призывает теневого духа для нанесения атаки (Отнимает 100 хп игроку)." +
                $"\n {DimensionalRift} -  позволяет скрыться в разломе и восстановить 250 хп. Урон босса по вам не проходит" +
                $"\n {Huganzakura} - Может быть выполнен только после призыва теневого духа, наносит 100 ед. урона");

            while (IsEnableGame)
            {
                if (healthBoss <= 0)
                {
                    Console.WriteLine("Босс Сдох!");
                    IsEnableGame = false;
                }

                else if (healthShadowMage <= 0)
                {
                    Console.WriteLine("Игрок Сдох!");
                    IsEnableGame = false;
                }

                else
                {
                    Console.WriteLine("Статистика Боса: \n Здоровье: {0} , Урон: {1} \n\nСтатистика игрока: \n Здоровье: {2} , Мана: {3} \n", healthBoss, damageBoss, healthShadowMage, manaPlayer);

                    Console.WriteLine("Введите заклинание: ");
                    enterSpell = Console.ReadLine();

                    switch (enterSpell)
                    {
                        case Fireball:

                            if (manaPlayer >= 30)
                            {
                                healthBoss -= 50;
                                manaPlayer -= 30;
                            }

                            else
                            {
                                Console.WriteLine("У вас не достаточно маны!");
                            }
                            break;

                        case Rashamon:

                            if (manaPlayer >= 50)
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (healthShadowMage <= 250)
                                    {
                                        healthShadowMage -= 100;                              
                                        Console.WriteLine("Ваше текущее здоровье равно: {0}/250", healthShadowMage);
                                        IsDimensionalRift = true;
                                    }                                 
                                }
                                manaPlayer -= 50;
                            }

                            else
                            {
                                Console.WriteLine("У вас не достаточно маны!");
                            }
                            break;

                        case DimensionalRift:

                            if (manaPlayer >= 45)
                            {
                                healthShadowMage += 250;                         
                                manaPlayer -= 45;
                                Console.WriteLine($"У вас здоровя востановлена на {healthShadowMage}");
                            }

                            else
                            {
                                Console.WriteLine("У вас не достаточно маны!");
                            }
                            break;

                        case Huganzakura:

                            if (IsDimensionalRift != false)
                            {
                                if (manaPlayer >= 50)
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        healthBoss -= 35;
                                        Thread.Sleep(1000);
                                        Console.WriteLine("Урон по босу теневыми духами: {0}", healthBoss);
                                    }
                                    manaPlayer -= 50;
                                }                              
                            }

                            else
                            {
                                Console.WriteLine($"Вам надо использовать заклинание {Rashamon}");
                            }
                            break;
                        
                        default:

                            Console.WriteLine("Вы не знаетете {0} это заклинания или вы произнесли его не правильно.", enterSpell);
                            break;
                    }

                    healthShadowMage -= damageBoss;
                    healthBoss += 10;
                    manaPlayer += 15;
                }
            }
        }
    }
}

        