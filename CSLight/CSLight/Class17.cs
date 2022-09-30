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
            #region variables int and string
            const string Rashamon = "2";
            const string Huganzakura = "4";
            const string DimensionalRift = "3";
            const string Fireball = "1";

            int minDamageNumber = 20;
            int maxDamageNumber = 100;

            int maxArmorNumber = 80;
            int minArmorNumber = 35;

            int minHealthNumber = 20;
            int maxHealthNumber = 150;

            int maxManaNumber = 150;
            int minManaNumber = 100;

            int regenerationHealth = 10;
            int regenerationMana = 15;

            bool IsEnableGame = true;
            bool IsDimensionalRift = false;

            string enterSpell;
            #endregion
            #region spel expenses

            int spelManaFireball = 30;
            int spelManaRashamon = 50;
            int spelManaDimensionalRift = 45;
            int spelManaHuganzakura = 50;
            int spelDamage = 50;
            int spelDamageHealthBoss = 35;
            int spelDamageHaelth = 100;
            int spelregenerationHealth = 250;

            #endregion
            #region random int
            Random random = new Random();

            int healthBoss = random.Next(minHealthNumber, maxHealthNumber);
            int armorBoss = random.Next(minArmorNumber, maxArmorNumber);
            int damageBoss = random.Next(minDamageNumber, maxDamageNumber);

            int healthShadowMage = random.Next(minHealthNumber, maxHealthNumber);
            int armorShadowMage = random.Next(minDamageNumber, maxDamageNumber);
            int manaPlayer = random.Next(minManaNumber, maxManaNumber);
            #endregion
            #region console
            Console.WriteLine($"Маг: здоровье:{healthShadowMage}, броня:{armorShadowMage}, урон:{manaPlayer}.");
            Console.WriteLine($"Босс: здоровье:{healthBoss}, броня:{armorBoss}, урон:{damageBoss}.");
            Console.Write("\nБитва началась! ");

            Console.WriteLine($"Передвами стоит огромный огр он настроен агресивно избежать драки не возможно приготовтесь к бою. \n Ваши доступные заклинания:" +

                $"\n {Fireball} - Огненый шар наносит 50 урона, отнимает 30 едениц маны." +
                $"\n {Rashamon} - призывает теневого духа для нанесения атаки (Отнимает 100 хп игроку)." +
                $"\n {DimensionalRift} -  позволяет скрыться в разломе и восстановить 250 хп. Урон босса по вам не проходит" +
                $"\n {Huganzakura} - Может быть выполнен только после призыва теневого духа, наносит 100 ед. урона");
            #endregion
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

                    Console.WriteLine("Введите заклинание:");
                    enterSpell = Console.ReadLine();

                    switch (enterSpell)
                    {
                        case Fireball:

                            if (manaPlayer >= spelManaFireball)
                            {
                                healthBoss -= spelDamage;
                                manaPlayer -= spelManaFireball;
                            }

                            else
                            {
                                Console.WriteLine("У вас не достаточно маны!");
                            }
                            break;

                        case Rashamon:

                            if (manaPlayer >= spelManaRashamon)
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (healthShadowMage <= spelDamageHaelth)
                                    {
                                        healthShadowMage -= spelDamageHaelth;
                                        Console.WriteLine($"Ваше текущее здоровье равно: {healthShadowMage}/250");
                                        IsDimensionalRift = true;
                                    }
                                }
                                manaPlayer -= spelManaRashamon;
                            }

                            else
                            {
                                Console.WriteLine("У вас не достаточно маны!");
                            }
                            break;

                        case DimensionalRift:

                            if (manaPlayer >= spelManaDimensionalRift)
                            {
                                healthShadowMage += spelregenerationHealth;
                                manaPlayer -= spelManaDimensionalRift;
                                Console.WriteLine($"У вас здоровя востановлена на {healthShadowMage}");
                            }

                            else
                            {
                                Console.WriteLine("У вас не достаточно маны!");
                            }
                            break;

                        case Huganzakura:

                            if (IsDimensionalRift)
                            {
                                if (manaPlayer >= spelManaHuganzakura)
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        healthBoss -= spelDamageHealthBoss;
                                        Thread.Sleep(1000);
                                        Console.WriteLine($"Урон по босу теневыми духами:,{healthBoss}");
                                    }
                                    manaPlayer -= spelManaHuganzakura;
                                }
                            }

                            else
                            {
                                Console.WriteLine($"Вам надо использовать заклинание {Rashamon}");
                            }
                            break;

                        default:

                            Console.WriteLine($"Вы не знаетете это заклинания или вы произнесли его не правильно, {enterSpell} ");
                            break;
                    }

                    healthShadowMage -= damageBoss;
                    healthBoss += regenerationHealth;
                    manaPlayer += regenerationMana;
                }
            }
        }
    }
}

