namespace CSLight
{
    class Class2
    {
        static void Main(string[] strings)
        {
            int numberOfPictures = 52;
            int numberOfPicturesInRow = 3;
            int numberOfPaintings = numberOfPictures / numberOfPicturesInRow;
            int extraPictures = numberOfPictures % numberOfPicturesInRow;

            Console.WriteLine($"{extraPictures} Осталось картинок\n{numberOfPaintings} картин в ряд");
        }
    }
}