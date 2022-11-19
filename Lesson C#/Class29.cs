namespace CSLight
{
    internal class Class29
    {
        const ConsoleKey MoveUpCommand = ConsoleKey.W;
        const ConsoleKey MoveDownCommand = ConsoleKey.S;
        const ConsoleKey MoveLeftCommand = ConsoleKey.A;
        const ConsoleKey MoveRightCommand = ConsoleKey.D;
        const ConsoleKey ExitCommand = ConsoleKey.Escape;
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;

            bool isPlaing = true;

            char[,] map = new char[,]
                {
                {'#','#','#','#','#','#'},
                {'#',' ','#',' ',' ','#'},
                {'#',' ',' ','#',' ','#'},
                {'#',' ',' ',' ',' ','#'},
                {'#',' ','#',' ','#','#'},
                {'#',' ','#',' ',' ','#'},
                {'#','#','#','#','#','#'}
                };
            int positionUserX = 1;
            int positionUserY = 1;
            int directionX = 0;
            int directionY = 0;

            DrawMap(map);
            DrawUser(positionUserY, positionUserX);

            while (isPlaing)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                ChangeDirection(key, ref directionX, ref directionY);

                if (map[positionUserX + directionX, positionUserY + directionY] != '#')
                {
                    MoveUser(ref positionUserX, ref positionUserY, directionX, directionY);
                }

                if (key.Key == ExitCommand)
                {
                    isPlaing = false;
                }
            }
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void DrawUser(int positionY, int positionX)
        {
            char player = '@';

            Console.SetCursorPosition(positionY, positionX);
            Console.Write(player);
        }

        static void MoveUser(ref int positionX, ref int positionY, int directionX, int directionY)
        {
            Console.SetCursorPosition(positionY, positionX);
            Console.Write(" ");

            positionX += directionX;
            positionY += directionY;

            DrawUser(positionY, positionX);
        }

        static void ChangeDirection(ConsoleKeyInfo key, ref int directionX, ref int directionY)
        {
            switch (key.Key)
            {
                case MoveUpCommand:
                    directionX = -1;
                    directionY = 0;
                    break;
                case MoveDownCommand:
                    directionX = 1;
                    directionY = 0;
                    break;
                case MoveLeftCommand:
                    directionX = 0;
                    directionY = -1;
                    break;
                case MoveRightCommand:
                    directionX = 0;
                    directionY = 1;
                    break;
            }
        }
    }
}

