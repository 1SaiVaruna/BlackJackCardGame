namespace BlackJackCardGame
{
	internal class Program
	{
		private static Random random = new Random();
		private static int playerScore = 0;
		private static int dealerScore = 0;

		static void Main(string[] args)
		{
			Console.WriteLine("WELCOME TO BLACKJACK");

			bool playAgain = true;

			while (playAgain)
			{
				PlayRound();
				Console.WriteLine("\nCURRENT SCORES: PLAYER: {0}, DEALER: {1}",playerScore, dealerScore);
				Console.WriteLine("WOULD YOU LIKE TO PLAY AGAIN? (Y/N)");
				playAgain = Console.ReadLine().ToUpper() == "Y";
			}

			Console.WriteLine("THANKS FOR PLAYING! FINAL SCORES: PLAYER: {0}, DEALER: {1}", playerScore, dealerScore);
		}

		static void PlayRound()
		{

		}

		static bool PlayerTurn(List<int> playerHand)
		{
			while (true)
			{
				Console.WriteLine("\nYOUR HAND: {0} (TOTAL: {1})", string.Join(", ", playerHand), CalculateHand(playerHand));
				Console.WriteLine("DO YOU WANT TO (H)IT OR (S)TAND?");
				string choice = Console.ReadLine().ToUpper();

				if (choice == "H")
				{
					playerHand.Add(DrawCard());
					int playerTotal = CalculateHand(playerHand);
					Console.WriteLine("YOU DREW A CARD. NEW TOTAL: {0}", playerTotal);

					if (playerTotal > 21)
					{
						Console.WriteLine("BUST! YOU WENT PAST 21");
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
					Console.WriteLine("INVALID INPUT. PLEASE ENTER 'H' OR 'S'");
				}
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
		static int DrawCard()
		{
			return random.Next(1, 11);
		}


	}
}
