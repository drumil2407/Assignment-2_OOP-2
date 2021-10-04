using System;
using System.Collections.Generic;

namespace A1
{
	class Program
	{


		static void Main(string[] args)
		{
			//Task 1 part
			//this will take input from user and input is card to pick

			Console.WriteLine("Enter the number of cards to pick: ");
			string line = Console.ReadLine();
			if (int.TryParse(line, out int numCards))
			{
				foreach (var card in CardPicker.PickSomeCards(numCards))
				{
					Console.WriteLine(card);
				}
			}
			else
			{
				Console.WriteLine("Please enter a valid number.");
			}
			//Task-2
			Random random = new Random(1);
			ParticleMovement particleMover = new ParticleMovement();
			while (true)
			{
				Console.Write("0 for base movement only\n1 if a magnetic field is present\n" +
							  "2 if a gravitational field is present\n3 for both fields\n");
				char key = Console.ReadKey().KeyChar;
				if (key != '0' && key != '1' && key != '2' && key != '3') return;
				int movementRange = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
				particleMover.MovementRange = movementRange;
				particleMover.SetMagneticField(key == '1' || key == '3');
				particleMover.SetGravitationalField(key == '2' || key == '3');
				Console.WriteLine($"\nParticle with a movement range of {movementRange} units" +
								  $" moved a total distance of {particleMover.DistanceMoved} units.\n");
			}


		}
	}

	//Task-1

	class CardPicker
	{
		static Random random = new Random(1);
		/// <summary>
		/// Picks a random (with replacement) number of cards.
		/// </summary>
		/// <param name="numCards">The number of cards to choose at random.</param>
		/// <returns>An array of strings where each string represents a card.</returns>
		public static string[] PickSomeCards(int numCards)
		{
			string[] pickedCards = new string[numCards];
			for (int i = 0; i < numCards; ++i)
			{
				pickedCards[i] = RandomValue() + " of " + RandomSuit();
			}
			return pickedCards;
		}
		/// <summary>
		/// Chooses a random value for a card (Ace, 2, 3, ... , Queen, King)
		/// </summary>
		/// <returns>A string that represents the value of a card</returns>
		enum Suit
		{

			Diamonds,
			Hearts,
			Clubs,
			Spades

		}

		enum Faces
		{

			Jack,
			Queen,
			King,
			Ace

		}

		private static string RandomValue()
		{
			int value = random.Next(1, 14);
			switch (value)
			{
				case 1:
					Faces Jack = Faces.Jack;
					return Jack.ToString();
				case 11:
					Faces Queen = Faces.Queen;
					return Queen.ToString();
				case 12:
					Faces King = Faces.King;
					return King.ToString();
				case 13:
					Faces Ace = Faces.Ace;
					return Ace.ToString();
				default:
					// The integers 2 -> 10 can just be converted to a string
					return value.ToString();
			}
		}
		/// <summary>
		/// Chooses a random suit for a card (Clubs, Diamonds, Hearts, Spades)
		/// </summary>
		/// <returns>A string that represents the suit of a card.</returns>
		private static string RandomSuit()
		{
			int value = random.Next(1, 5);
			switch (value)
			{
				case 1:
					Suit Diamonds = Suit.Diamonds;
					return Diamonds.ToString();
				case 2:
					Suit Hearts = Suit.Hearts;
					return Hearts.ToString();
				case 3:
					Suit Clubs = Suit.Clubs;
					return Clubs.ToString();
				default:
					Suit Spades = Suit.Spades;
					return Spades.ToString();
			}
		}
	}
	//Task-2
	class ParticleMovement
	{
		public const int BASE_MOVEMENT = 3;
		public const int GRAVITY_MOVEMENT = 2;

		//1.Setting up a property and backing field
		private int movementRange;
		public int MovementRange
		{
			get { return movementRange; }
			set { movementRange = value; }

		}

		//2. Setting up a property and a backing field
		private bool gravitationalField;
		public bool GravitationalField
		{
			get { return gravitationalField; }
			set { gravitationalField = value; }

		}
		//3. Setting up a property and a backing field
		private bool magneticField;
		public bool MagneticField
		{

			get { return magneticField; }
			set { gravitationalField = value; }

		}
		//4.Auto implemented property

		public double Distance
		{
			get; private set;

		}


		public decimal MagneticMultiplier = 1M;
		public int GravityMovement = 0;
		public int DistanceMoved;

		public void CalculateDistance()
		{
			DistanceMoved = (int)(movementRange * MagneticMultiplier) + BASE_MOVEMENT + GravityMovement;
		}




	}



}
