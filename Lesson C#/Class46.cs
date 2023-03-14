namespace CSLight
{
    internal class Class46
    {
        static void Main(string[] args)
        {
            Field field = new Field();

            Console.WriteLine("Война между двух стран  Россия и Германия");
            Console.ReadKey();

            field.Battle();
            field.ShowBattleResult();
        }
    }

    class Field
    {
        private Platoon _platoonRussia = new Platoon();
        private Platoon _platoonGermany = new Platoon();

        private Soldier _firstSolider;
        private Soldier _secondSolider;

        public void Battle()
        {
            while (_platoonRussia.GetCountSoliders() > 0 && _platoonGermany.GetCountSoliders() > 0)
            {
                _firstSolider = _platoonRussia.GetSoldierFromPlatoon();
                _secondSolider = _platoonGermany.GetSoldierFromPlatoon();

                _platoonRussia.ShowInfo();
                _platoonGermany.ShowInfo();

                _firstSolider.TakeDamege(_secondSolider.Damage);
                _secondSolider.TakeDamege(_firstSolider.Damage);

                _firstSolider.UseSpecialAttack();
                _secondSolider.UseSpecialAttack();

                RemoveSolider();
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
        }

        public void ShowBattleResult()
        {
            if (_platoonRussia.GetCountSoliders() > 0 && _platoonGermany.GetCountSoliders() > 0)
            {
                Console.WriteLine("Ничья, оба страны погибли");
            }
            else if (_platoonRussia.GetCountSoliders() <= 0)
            {
                Console.WriteLine("Взвод страны Россия победил!");
            }
            else if (_platoonGermany.GetCountSoliders() <= 0)
            {
                Console.WriteLine("Взвод страны Германие победил!");
            }
        }

        private void RemoveSolider()
        {
            if (_firstSolider.Health <= 0)
            {
                _platoonRussia.RemoveSoldierFromPlatoon(_firstSolider);
            }

            if (_secondSolider.Health <= 0)
            {
                _platoonGermany.RemoveSoldierFromPlatoon(_secondSolider);
            }
        }
    }

    class Platoon
    {
        private List<Soldier> _soldiers = new List<Soldier>();
        private Soldier soldier;
        private Random _random = new Random();

        public Platoon()
        {
            CreateNew(10, _soldiers);
        }

        public void ShowInfo()
        {
            Console.WriteLine(" Взвод");
            foreach (var solider in _soldiers)
            {
                Console.WriteLine($"{solider.Name}. Здоровье: {solider.Health}. Урон: {solider.Damage}.");
            }
        }

        public void RemoveSoldierFromPlatoon(Soldier soldier)
        {
            _soldiers.Remove(soldier);
        }

        public Soldier GetSoldierFromPlatoon()
        {
            return _soldiers[_random.Next(0, _soldiers.Count)];
        }

        public int GetCountSoliders()
        {
            return _soldiers.Count;
        }

        private void CreateNew(int numberOfSoldiers, List<Soldier> soldier)
        {
            for (int i = 0; i < numberOfSoldiers; i++)
            {
                soldier.Add(GetSoldier());
            }
        }

        private Soldier GetSoldier()
        {
            int minNumber = 0;
            int maxNumber = 3;

            int newSolider = _random.Next(minNumber, maxNumber);

            if (newSolider == 1)
            {
                return new Sniper("Снайпер", 100, 50);
            }
            else if (newSolider == 2)
            {
                return new Tankis("Танкис", 100, 45);
            }
            else
            {
                return new Medic("Медик", 100, 40);
            }
        }
    }

    class Soldier
    {
        public Soldier(int health, int damage, string name)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public string Name { get; protected set; }

        public void TakeDamege(int damageSolider)
        {
            Health -= damageSolider;

            Console.WriteLine();
            Console.WriteLine($"{Name} нанес {damageSolider} урона");
        }

        public void UseSpecialAttack()
        {
            Random random = new Random();

            int rangeMaxima = 100;
            int chanceAbility = 10;
            int chanceUsingAbility = random.Next(rangeMaxima);

            if (chanceUsingAbility < chanceAbility)
            {
                UsePower();
            }
        }

        protected virtual void UsePower() { }
        protected virtual void HealthPlatoon() { }

    }

    class Sniper : Soldier
    {
        private int _damageBuff = 10;
        public Sniper(string name, int health, int damage) : base(health, damage, name) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} Стреляет большим критическим уроном ");
            Damage += _damageBuff;
        }
    }

    class Tankis : Soldier
    {
        private int _damageBuff = 1000;
        private int _healthBuff = 25;

        public Tankis(string name, int health, int damage) : base(health, damage, name) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} Увеличивает Урон и востонавливает часть танка ");
            Damage += _damageBuff;
            Health += _healthBuff;
        }
    }

    class Medic : Soldier
    {
        private int _damageBuff = 100;
        private int _healthBuff = 50;

        public Medic(string name, int health, int damage) : base(health, damage, name) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} Востонавливает часть здоровя звода");
            Damage *= _damageBuff;
            HealthPlatoon();
        }

        protected override void HealthPlatoon()
        {
            Health *= _healthBuff;
        }
    }
}
