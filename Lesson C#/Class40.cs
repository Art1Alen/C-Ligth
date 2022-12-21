namespace CSLight
{
    internal class Class40
    {
        static void Main()
        {
            const string CommandShowAllBooks = "3";
            const string CommandAddBook = "1";
            const string CommandSearchBook = "2";
            const string CommandDeletteBook = "4";
            const string CommandExit = "5";

            BookStorage bookStorage = new BookStorage();

            bool isStorageWork = true;

            while (isStorageWork)
            {
                Console.WriteLine("Меню Библиотеке");
                Console.WriteLine($"{CommandAddBook} - Добавить Книгу\n" +
                    $"{CommandSearchBook} - Искать Книгу\n" +
                    $"{CommandShowAllBooks} - Покозать все Книги\n" +
                    $"{CommandDeletteBook} - Удалить Книгу \n" +
                    $"{CommandExit} - Выход\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddBook:
                        bookStorage.AddBook();
                        break;

                    case CommandSearchBook:
                        bookStorage.SearchBooks();
                        break;

                    case CommandShowAllBooks:
                        bookStorage.ShowAllBooks();
                        break;

                    case CommandDeletteBook:
                        bookStorage.DelleteBook();
                        break;

                    case CommandExit:
                        isStorageWork = false;
                        break;
                }

                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    class Book
    {   
        public int Index { get; private set; }
        public int IssueYear { get; private set; }
        public string Author { get; private set; }
        public string Name { get; private set; }    
        private static int _counter = 0;

        public Book(string author, string name, int issueYear)
        {
            Index = ++_counter;
            Author = author;
            Name = name;
            IssueYear = issueYear;
        }

        public void Show()
        {
            Console.WriteLine($"{Index}  :Имя {Name}  :Автор {Author}  :Дата Релиза {IssueYear}");
        }
    }

    class BookStorage
    {
        const string CommandAuthorName = "1";
        const string CommandBookName = "2";
        const string CommandrIssueYear = "3";

        private List<Book> _books = new List<Book>();

        public BookStorage()
        {
            _books.Add(new Book("Энн Эпплбаум", "Гулаг", 1602));
            _books.Add(new Book("Елена Михайлова", "Перо буможной птицы", 1597));
            _books.Add(new Book("Виктор Пелевин", "KGBT", 475));
            _books.Add(new Book("Татьяна Устинова", "Руковой подарок", 1937));
            _books.Add(new Book("Шарлотта Брандиш", "Леди из Фроингема", 1954));
            _books.Add(new Book("Ольга Примаченко", "У себе нежно", 1954));
            _books.Add(new Book("Фредрик Бакман", "Здесь была Бритт-Мари", 1867));
        }

        public void ShowAllBooks()
        {          
            foreach (Book book in _books)
            {
                book.Show();
            }           
        }

        public void AddBook()
        {
            Console.WriteLine("Имя Автора");
            string authorName = Console.ReadLine();

            Console.WriteLine("Название Книги");
            string bookName = Console.ReadLine();

            Console.WriteLine("Дата Релиза");
            int issueYear;

            int.TryParse(Console.ReadLine(), out issueYear);
            Book newBook = new Book(authorName, bookName, issueYear);

            _books.Add(newBook);
        }

        public void SearchBooks()
        {           
            Console.WriteLine("Меню поиска");
            Console.WriteLine($"{CommandAuthorName}  - Поиск по Автору\n" +
                $"{CommandBookName}  - Поиск по Название Книги\n" +
                $"{CommandrIssueYear}  - Поиск по даты Релиза\n");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case CommandAuthorName:
                    SearchAuthorNameBooks();
                    break;

                case CommandBookName:
                    SearchBookName();
                    break;

                case CommandrIssueYear:
                    SearchIssueYear();
                    break;
            }
        }

        public void SearchAuthorNameBooks()
        {
            Console.WriteLine("Введите название Автора");
            string authorName = Console.ReadLine().ToLower();

            foreach (Book book in _books)
            {
                if (book.Author == authorName)
                {
                    book.Show();
                }
            }
        }

        public void SearchBookName()
        {
            Console.WriteLine("Введите название книги");
            string bookName = Console.ReadLine().ToLower();

            foreach (Book book in _books)
            {
                if (book.Name == bookName)
                {
                    book.Show();
                }
            }
        }

        public void SearchIssueYear()
        {
            Console.WriteLine("Введите даты Релиза");
       
            int.TryParse(Console.ReadLine(), out int issueYear);

            foreach (Book book in _books)
            {
                if (book.IssueYear == issueYear)
                {
                    book.Show();
                }
            }
        }

        public void DelleteBook()
        {
            Console.WriteLine("Введите Индеск книги"); 

            if( int.TryParse(Console.ReadLine(), out int index))
            {
                _books.RemoveAt(index - 1);
            }                
        }
    }
}

