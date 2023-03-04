namespace CSLight
{
	internal class Class43
	{
		private static void Main(string[] args)
		{
			Dispatcher dispatcher = new Dispatcher();

			Console.WriteLine("Введите количество поездов");
			int.TryParse(Console.ReadLine(), out int quantityTrains);

			while (quantityTrains > 0)
			{
				Console.Clear();

				dispatcher.CreateTrain();

				quantityTrains--;
			}
		}
	}

	class Train
	{
		private int _universalNumber;
		private string _direction;
		private int _purchasedTickets;
		private int _maxPeopleInCar;
		private int _trainCars;

		public Train(int universalNumber, string direction, int purchasedTickets, int maxPeopleInCar, int traincars)
		{
			_universalNumber = universalNumber;
			_direction = direction;
			_purchasedTickets = purchasedTickets;
			_maxPeopleInCar = maxPeopleInCar;
			_trainCars = traincars;
		}

		public void Show()
		{
			Console.WriteLine($"Поезд под номером {_universalNumber}, направляется {_direction}, с {_purchasedTickets} пассажиров, максималный человек в одном вагоне поезда - {_maxPeopleInCar}, Имет {_trainCars} вагонов в поезде !");
		}
	}

	class Dispatcher
	{
		private int _universalNumber = 0;
		private int maxPeopleInTrainCar = 100;

		private List<string> _sheetDirections = new List<string>();

		public Dispatcher()
		{
			CreateRosterDirection();
		}

		public void CreateTrain()
		{
			_universalNumber++;

			string direction = _sheetDirections[ChoiceDirection()];

			int purchasedTickets = SellTicket();
			int traincars = CreateTrainSize(purchasedTickets);

			Train train = new Train(_universalNumber, direction, purchasedTickets, maxPeopleInTrainCar, traincars);

			Console.SetCursorPosition(0, 6);
			train.Show();

			Console.ReadKey();
		}

		public int ChoiceDirection()
		{
			bool IsChoice = false;

			int choiceNumber = 0;

			Console.WriteLine("Ни один поезд не готов");

			while (IsChoice != true)
			{
				Console.WriteLine("Выбор направления:\n");

				foreach (var Direction in _sheetDirections)
				{
					Console.WriteLine(Direction);
				}

				string userChoice = Console.ReadLine();

				int.TryParse(userChoice, out int result);

				if (result > 0 && _sheetDirections.Count >= result)
				{
					IsChoice = true;
					choiceNumber = result - 1;
				}
			}

			Console.Clear();
			Console.WriteLine($"Поезд под номером {_universalNumber} поедить {_sheetDirections[choiceNumber]}");

			return choiceNumber;
		}

		public int SellTicket()
		{
			Random random = new Random();

			int minPeopleToStart = 100;
			int maxPeopleToStart = 300;

			int SelledTicket = random.Next(minPeopleToStart, maxPeopleToStart);

			Console.WriteLine($"В Поезде под номером {_universalNumber} продона {SelledTicket} билетов");

			return SelledTicket;
		}

		public int CreateTrainSize(int purchasedTickets)
		{
			int traincars;

			double trainLength = Math.Ceiling(Convert.ToDouble(purchasedTickets) / Convert.ToDouble(maxPeopleInTrainCar));
			traincars = Convert.ToInt32(trainLength);

			Console.WriteLine($"В Поезде под номером {_universalNumber} имеет  {traincars} вагона");

			return traincars;
		}

		private void CreateRosterDirection()
		{
			_sheetDirections.Add("Москва - Италия");
			_sheetDirections.Add("Италия - Франция");
			_sheetDirections.Add("Франция - Германия");
		}
	}
}


