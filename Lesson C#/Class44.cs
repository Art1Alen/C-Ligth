using System;
using System.Collections.Generic;

namespace CSLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;

            while (isWork)
            {
                Arena arena = new Arena();

                if (arena.TryCreativeBattle())
                {
                    Console.ReadKey();
                    Console.Clear();
                    arena.Battle();
                    arena.ShowBattleResult();
                }
            }
        }
    }

    class Arena
    {
        private Fighter _firstFighter;
        private Fighter _secondFighter;
        private List<Fighter> _fighters = new List<Fighter>();

        public Arena()
        {
            _fighters.Add(new Archer("Лучник", 100, 100, 40));
            _fighters.Add(new Wizard("Маг", 100, 100, 15));
            _fighters.Add(new Knight("Рыцарь", 100, 100, 50));
            _fighters.Add(new Barbarian("Варвар", 90, 100, 30));
            _fighters.Add(new Mystic("Мистик", 100, 100, 22));
        }

        public bool TryCreativeBattle()
        {
            Console.WriteLine("Боец 1");
            ChooseFighter(out _firstFighter);

            Console.WriteLine("Боец 2");
            ChooseFighter(out _secondFighter);

            if (_firstFighter == null || _secondFighter == null)
            {
                Console.WriteLine("Ошибка выбора бойца");
                return false;
            }
            else
            {
                Console.WriteLine("Бойцы выбраны");
                return true;
            }
        }

        public void ShowBattleResult()
        {
            if (_firstFighter.Health <= 0 && _secondFighter.Health <= 0)
            {
                Console.WriteLine("Ничья, оба погибли");
            }
            else if (_firstFighter.Health <= 0)
            {
                Console.WriteLine($"{_secondFighter.Name} победил!");
            }
            else if (_secondFighter.Health <= 0)
            {
                Console.WriteLine($"{_firstFighter.Name} победил!");
            }
        }

        public void Battle()
        {
            while (_firstFighter.Health > 0 && _secondFighter.Health > 0)
            {
                _firstFighter.ShowStats();
                _secondFighter.ShowStats();
                _firstFighter.TakeDamege(_secondFighter.Damage);
                _secondFighter.TakeDamege(_firstFighter.Damage);
                _firstFighter.UseSpecialAttack();
                _secondFighter.UseSpecialAttack();
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ChooseFighter(out Fighter fighter)
        {
            ShowFighters();

            Console.Write("Введите номер бойца: ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int fighterID);

            if (isNumber == false)
            {
                Console.WriteLine("Ошибка! Вы ввели не коректные данные.");
                fighter = null;
            }
            else if (fighterID > 0 && fighterID - 1 < _fighters.Count)
            {
                fighter = _fighters[fighterID - 1];
                _fighters.Remove(fighter);

                Console.WriteLine("Боец успешно выбран.");
            }
            else
            {
                Console.WriteLine("Бойца с таким номером отсутствует.");
                fighter = null;
            }
        }

        private void ShowFighters()
        {
            Console.WriteLine("Список доступный бойцов");

            for (int i = 0; i < _fighters.Count; i++)
            {
                Console.Write(i + 1);
                _fighters[i].ShowStats();
            }
        }
    }

    class Fighter
    {
        public Fighter(string name, int health, int damage, int armor)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Armor = armor;
        }

        public string Name { get; protected set; }
        public float Health { get; protected set; }
        public float Armor { get; protected set; }
        public float Damage { get; protected set; }

        public void TakeDamege(float damageFighter)
        {
            float finalDamage = 0;
            int absorbedArmorFactor = 100;

            if (Armor == 0)
            {
                Health -= damageFighter;
            }
            else
            {
                finalDamage = damageFighter / absorbedArmorFactor * Armor;
                Armor -= finalDamage;
                Health -= finalDamage;
            }

            Console.WriteLine($"{Name} нанес {finalDamage} урона");
        }

        public void ShowStats()
        {
            Console.WriteLine($" {Name}. Здоровье: {Health}. Броня: {Armor} Урон {Damage}");
        }

        public void UseSpecialAttack()
        {
            Random random = new Random();
            int maxNumbers = 80;
            int minNumbers = 10;

            int chanceUsingAbility = random.Next(minNumbers, maxNumbers);
            int chanceAbility = 20;

            if (chanceUsingAbility < chanceAbility)
            {
                UsePower();
            }
        }

        protected virtual void UsePower() { }
    }

    class Archer : Fighter
    {
        private int _damageBuff = 55;
        private int _armorBuff = 45;

        public Archer(string name, int health, int armor, int damage) : base(name, health, damage, armor) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} Урон и броня увелечены");
            Damage += _damageBuff;
            Armor += _armorBuff;
        }
    }

    class Knight : Fighter
    {
        private int _healthBuff = 60;

        public Knight(string name, int health, int armor, int damage) : base(name, health, damage, armor) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} ипользовал молитву. Здоровье увелечено");
            Health += _healthBuff;
        }
    }

    class Wizard : Fighter
    {
        private int _damageBuff = 20;

        public Wizard(string name, int health, int armor, int damage) : base(name, health, damage, armor) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} ипользовал зелья силы. Урон увелечено");
            Damage += _damageBuff;
        }
    }

    class Barbarian : Fighter
    {
        private int _damageBuff = 60;
        private int _armorBuff = 50;

        public Barbarian(string name, int health, int armor, int damage) : base(name, health, damage, armor) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} укрепил свои мышцы. Урон и броня увеличены");
            Armor += _armorBuff;
            Damage += _damageBuff;
        }
    }

    class Mystic : Fighter
    {
        private int _armorBuff = 50;

        public Mystic(string name, int health, int armor, int damage) : base(name, health, damage, armor) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} использует мистическую силу. Броня увеличена");
            Armor += _armorBuff;
        }
    }
}

