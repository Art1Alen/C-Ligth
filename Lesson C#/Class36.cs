namespace CSLight
{
    internal class Class36
    {
        static void Main()
        {
            Player player = new Player(100, 25, 45);
            player.PlayerStatistics();
        }
    }

    class Player
    {
        private int _health;
        private int _armor;
        private int _damage;
       
        public Player(int health, int armor, int damage)
        {
            _health = health;
            _armor = armor;
            _damage = damage;
        }

        public void PlayerStatistics()
        {
            Console.WriteLine($"Здоровя {_health}\nБроня {_armor}\nУрон {_damage}");
        }
    }
}
