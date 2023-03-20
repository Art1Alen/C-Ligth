namespace CSLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            int stepBeweenSpecialAtteck = 8;

            while (isWork)
            {
                Arena arena = new Arena();

                if (arena.TryCreativeBattle())
                {
                    Console.ReadKey();
                    Console.Clear();
                    arena.Battle(stepBeweenSpecialAtteck);
                    arena.ShowBattleResult();
                    isWork = false;
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
            _fighters.Add(new Archer("Лучник", 100, 100, 40, 8));
            _fighters.Add(new Wizard("Маг", 100, 100, 15, 8));
            _fighters.Add(new Knight("Рыцарь", 100, 100, 50, 8));
            _fighters.Add(new Barbarian("Варвар", 90, 100, 30, 8));
            _fighters.Add(new Mystic("Мистик", 100, 100, 22, 8));
        }


        public bool TryCreativeBattle()
        {
            Console.WriteLine("Боец 1");
            _firstFighter = ChooseFighter();

            Console.WriteLine("Боец 2");
            _secondFighter = ChooseFighter();

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

        public void Battle(int stepBetweenSpecialAtteck)
        {
            int MinutesLeft = stepBetweenSpecialAtteck;

            while (_firstFighter.Health > 0 && _secondFighter.Health > 0)
            {
                Console.WriteLine($"Осталось времяни до суперудар {MinutesLeft}");

                _firstFighter.ShowStats();
                _secondFighter.ShowStats();

                MinutesLeft--;

                if (MinutesLeft <= 0)
                {
                    _firstFighter.UseSpecialAttack();
                    _secondFighter.UseSpecialAttack();

                    MinutesLeft = stepBetweenSpecialAtteck;
                }
                else
                {
                    _firstFighter.Attack(_secondFighter);
                    _secondFighter.Attack(_firstFighter);
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private Fighter ChooseFighter()
        {
            ShowFighters();

            bool isCorretNumber = false;

            Fighter templatefighter = null;

            while (isCorretNumber == false)
            {
                Console.Write("Введите номер бойца: ");
                bool isNumber = int.TryParse(Console.ReadLine(), out int fighterID);

                if (isNumber == false)
                {
                    Console.WriteLine("Ошибка! Вы ввели не коректные данные.");
                }
                else if (fighterID > 0 && fighterID - 1 < _fighters.Count)
                {
                    templatefighter = _fighters[fighterID - 1];
                    _fighters.Remove(templatefighter);

                    Console.WriteLine("Боец успешно выбран.");
                    isCorretNumber = true;
                }
                else
                {
                    Console.WriteLine("Бойца с таким номером отсутствует.");
                }

                Console.Clear();
            }

            return templatefighter;
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

        public void Attack(Fighter enemy)
        {
            TakeDamege(enemy.Damage);
        }

        public void TakeDamege(float damage)
        {
            float finalDamage = 0;
            int absorbedArmorFactor = 100;

            if (Armor == 0)
            {
                Health -= damage;
            }
            else
            {
                finalDamage = damage / absorbedArmorFactor * Armor;
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
            UsePower();
        }

        protected virtual void UsePower() { }
    }

    class Archer : Fighter
    {
        private int _damageBuff = 55;
        private int _armorBuff = 45;

        public Archer(string name, int health, int armor, int damage, int minutesLeft) : base(name, health, damage, armor) { }

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
        private int _armorBuff = 60;

        public Knight(string name, int health, int armor, int damage, int minutesLeft) : base(name, health, damage, armor) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} ипользовал молитву. Здоровье и броня увелечено");
            Health += _healthBuff;
            Armor += _armorBuff;
        }
    }

    class Wizard : Fighter
    {
        private int _damageBuff = 20;
        private int _heaithBuff = 5;

        public Wizard(string name, int health, int armor, int damage, int minutesLeft) : base(name, health, damage, armor) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} ипользовал зелья силы. Урон увелечено здоровя увиличен");
            Damage += _damageBuff;
            Health += _heaithBuff;
        }
    }

    class Barbarian : Fighter
    {
        private int _damageBuff = 60;

        public Barbarian(string name, int health, int armor, int damage, int minutesLeft) : base(name, health, damage, armor) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} Использовал руну DoubleDamade. Урон увиличен");
            Damage += _damageBuff;
        }
    }

    class Mystic : Fighter
    {
        private int _armorBuff = 50;
        private int _damageBuff = 6;

        public Mystic(string name, int health, int armor, int damage, int minutesLeft) : base(name, health, damage, armor) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} использует Bloodlast силу. Броня увеличена Урон уменшился");
            Armor += _armorBuff;
            Damage -= _damageBuff;
        }
    }
}

