namespace BlackJackCardGame
{
	internal class Program
	{
		private static Random random = new Random();
		private static int playerScore = 0;
		private static int dealerScore = 0;

		static void ClearConsoleWithHeader()
		{
			Console.Clear();
			Console.WriteLine("BLACKJACK CARD GAME [ 21 ]");
			Console.WriteLine("\n-----------------------------");
			Console.WriteLine("\nCURRENT SCORES: PLAYER: {0}, DEALER: {1}", playerScore, dealerScore);
		}

		static void Main(string[] args)
		{
			Console.Title = "BLACKJACK CARD GAME";

			ClearConsoleWithHeader();

			bool playAgain = true;

			while (playAgain)
			{
				PlayRound();
				Console.WriteLine("\nCURRENT SCORES: PLAYER: {0}, DEALER: {1}",playerScore, dealerScore);
				Console.Write("\nWOULD YOU LIKE TO PLAY AGAIN? (Y/N) ");
				playAgain = Console.ReadLine().ToUpper() == "Y";
			}

			Console.WriteLine("\nTHANKS FOR PLAYING! FINAL SCORES: PLAYER: {0}, DEALER: {1}", playerScore, dealerScore);
		}

		static void PlayRound()
		{
			ClearConsoleWithHeader();

			List<int> playerHand = new List<int> { DrawCard(), DrawCard() };
			List<int> dealerHand = new List<int> { DrawCard(), DrawCard() };

			Console.WriteLine("\n-----------------------------");
			Console.WriteLine("\nPLAYER'S HAND: {0} (TOTAL: {1})", string.Join(", ", playerHand), CalculateHand(playerHand));
			Console.WriteLine("\nDEALER'S HAND: {0}, ?", dealerHand[0]);
			Console.WriteLine("\n-----------------------------");

			if (PlayerTurn(playerHand) && DealerTurn(dealerHand))
			{
				WinnerRound(playerHand, dealerHand);
			}

		}

		static bool PlayerTurn(List<int> playerHand)
		{

			while (true)
			{
				Console.Write("\nDO YOU WANT TO (H)IT OR (S)TAND? ");
				string choice = Console.ReadLine().ToUpper();

				if (choice == "H")
				{
					playerHand.Add(DrawCard());
					int playerTotal = CalculateHand(playerHand);
					Console.WriteLine("\nYOU DREW A CARD. NEW TOTAL: {0}", playerTotal);

					if (playerTotal > 21)
					{
						Console.WriteLine("\nYOU BUST!");
						dealerScore++;
						return false;
					}
				}

				else if (choice == "S")
				{
					break;
				}

				else
				{
					Console.Write("\nINVALID INPUT. PLEASE ENTER 'H' OR 'S' ");
				}
			}

			return true;
		}

		static bool DealerTurn(List<int> dealerHand)
		{
			while (CalculateHand(dealerHand) < 17)
			{
				dealerHand.Add(DrawCard());
			}

			int dealerTotal = CalculateHand(dealerHand);

			if (dealerTotal > 21)
			{
				Console.WriteLine("\nDEALER BUSTS!");
				playerScore++;
				return false;
			}

			return true;
		}

		static int CalculateHand(List<int> hand)
		{
			int total = hand.Sum();
			int aceCount = hand.Count(card => card == 1);

			while (total <= 11 && aceCount > 0)
			{
				total += 10;
				aceCount--;
			}

			return total;
		}

		static void WinnerRound(List<int> playerHand, List<int> dealerHand)
		{
			int playerTotal = CalculateHand(playerHand);
			int dealerTotal = CalculateHand(dealerHand);

			Console.WriteLine("\n----------------------------");
			Console.WriteLine("\nPLAYER'S HAND {0} (TOTAL: {1})", string.Join(", ", playerHand), playerTotal);
			Console.WriteLine("\nDEALER'S HAND {0} (TOTAL: {1})", string.Join(", ", dealerHand), dealerTotal);
			Console.WriteLine("\n-----------------------------");

			if (playerTotal > dealerTotal)
			{
				Console.WriteLine("\nPLAYER WINS THIS ROUND!");
				playerScore++;
			}

			else if (dealerTotal > playerTotal)
			{
				Console.WriteLine("\nDEALER WINS THIS ROUND!");
				dealerScore++;
			}

			else
			{
				Console.WriteLine("\nTIE!");
			}
		}

		static int DrawCard()
		{
			return random.Next(1, 11);
		}


	}
}
