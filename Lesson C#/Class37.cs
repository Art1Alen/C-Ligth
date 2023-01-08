namespace CSLight
{
    internal class Class37
    {
        static void Main()
        {
            Renderer renderer = new Renderer();
            Player player = new Player(5, 5);

            renderer.DrawPlayer(player.X,player.Y);
        }
    }
    class Renderer
    {
        public void DrawPlayer(int x, int y,char symbol = '@')
        {
            Console.SetCursorPosition(x,y);
            Console.WriteLine(symbol);           
        } 
    }
    class Player
    {               
        public int X { get; private set; }
        public int Y { get; private set; }
                          
        public Player(int positionX, int positionY)
        {
            X = positionX;
            Y = positionY;
        }
    }
}
