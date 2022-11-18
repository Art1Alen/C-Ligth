namespace CSLight
{
    internal class Class29
    {
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

            Map(map);
            DrawingUser(positionUserY, positionUserX);

            while (isPlaing)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                ChangeDirection(key, ref directionX, ref directionY);

                if (map[positionUserX + directionX, positionUserY + directionY] != '#')
                {
                    MoveUser(ref positionUserX, ref positionUserY, directionX, directionY);
                }

                if (key.Key == ConsoleKey.Escape)
                {
                    isPlaing = false;
                }
            }
        }

        static void Map(char[,] map)
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

        static void DrawingUser(int positionY, int positionX)
        {
            Console.SetCursorPosition(positionY, positionX);
            Console.Write('@');
        }

        static void MoveUser(ref int positionX, ref int positionY, int directionX, int directionY)
        {
            Console.SetCursorPosition(positionY, positionX);
            Console.Write(" ");

            positionX += directionX;
            positionY += directionY;

            DrawingUser(positionY, positionX);
        }

        static void ChangeDirection(ConsoleKeyInfo key, ref int directionX, ref int directionY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    directionX = -1;
                    directionY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    directionX = 1;
                    directionY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    directionX = 0;
                    directionY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    directionX = 0;
                    directionY = 1;
                    break;
            }
        }
    }
}

