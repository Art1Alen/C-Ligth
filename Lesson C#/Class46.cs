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
        private Platoon _russia = new Platoon();
        private Platoon _germany = new Platoon();

        private Soldier _firstSolider;
        private Soldier _secondSolider;

        public void Battle()
        {
            while (_russia.GetCountSoliders() > 0 && _germany.GetCountSoliders() > 0)
            {
                _firstSolider = _russia.GetSoldier();
                _secondSolider = _germany.GetSoldier();

                _russia.ShowInfo();
                _germany.ShowInfo();

                _firstSolider.Attack(_secondSolider);
                _secondSolider.Attack(_firstSolider);

                RemoveDeadSoldiers();
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
        }

        public void ShowBattleResult()
        {
            if (_russia.GetCountSoliders() == 0 && _germany.GetCountSoliders() == 0)
            {
                Console.WriteLine("Ничья, оба страны погибли");
            }
            else if (_russia.GetCountSoliders() > 0)
            {
                Console.WriteLine("Взвод страны Россия победил!");
            }
            else
            {
                Console.WriteLine("Взвод страны Германие победил!");
            }
        }

        private void RemoveDeadSoldiers()
        {
            if (_firstSolider.Health <= 0)
            {
                _russia.RemoveSoldier(_firstSolider);
            }

            if (_secondSolider.Health <= 0)
            {
                _germany.RemoveSoldier(_secondSolider);
            }
        }
    }

    class Platoon
    {
        private List<Soldier> _soldiers = new List<Soldier>();
        private Random _random = new Random();

        public Platoon()
        {
            CreateNew(10, _soldiers);
        }

        public void ShowInfo()
        {
            Console.WriteLine(" Взвод");

            foreach (Soldier solider in _soldiers)
            {
                Console.WriteLine($"{solider.Name}. Здоровье: {solider.Health}. Урон: {solider.Damage}.");
            }
        }

        public void RemoveSoldier(Soldier soldier)
        {
            _soldiers.Remove(soldier);
        }

        public Soldier GetSoldier()
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
                soldier.Add(Create());
            }
        }

        private Soldier Create()
        {
            List<Soldier> soldiers = new List<Soldier>()
            {
                 new Sniper("Снайпер", 100, 50),
                 new Tankis("Танкис", 100, 45),
                 new Medic("Медик", 100, 40),
            };

            int minNumber = 0;
            int maxNumber = soldiers.Count;

            int number = _random.Next(minNumber, maxNumber);

            return soldiers[number];
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

    public virtual void Attack(Soldier enemy) { }

}

class Sniper : Soldier
{
    private int _damageBuff = 10;
    public Sniper(string name, int health, int damage) : base(health, damage, name) { }

    public override void Attack(Soldier enemy)
    {
        enemy.TakeDamege(Damage);
        Console.WriteLine($"{Name} Стреляет большим критическим уроном ");
        Damage += _damageBuff;
    }
}

class Tankis : Soldier
{
    private int _damageBuff = 1000;
    private int _healthBuff = 25;

    public Tankis(string name, int health, int damage) : base(health, damage, name) { }

    public override void Attack(Soldier enemy)
    {
        enemy.TakeDamege(Damage);

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

    protected void HealthPlatoon()
    {
        Health *= _healthBuff;
    }

    public override void Attack(Soldier enemy)
    {
        enemy.TakeDamege(Damage);

        Console.WriteLine($"{Name} Востонавливает часть здоровя звода");
        Damage *= _damageBuff;
        HealthPlatoon();
    }
}

