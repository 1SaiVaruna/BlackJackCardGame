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
			List<int> playerHand = new List<int> { DrawCard(), DrawCard() };
			List<int> dealerHand = new List<int> { DrawCard(), DrawCard() };

			Console.WriteLine("\nYOUR HAND: {0} (TOTAL: {1}", string.Join(", ", playerHand), CalculateHand(playerHand));
			Console.WriteLine("DEALER'S HAND: {0}, ?", dealerHand[0]);

			if (PlayerTurn(playerHand) && DealerTurn(dealerHand))
			{
				WinnerRound(playerHand, dealerHand);
			}

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
						Console.WriteLine("YOU BUST!");
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

		static bool DealerTurn(List<int> dealerHand)
		{
			while (CalculateHand(dealerHand) < 17)
			{
				dealerHand.Add(DrawCard());
			}

			int dealerTotal = CalculateHand(dealerHand);
			Console.WriteLine("DEALER'S HAND: {0} (TOTAL: {1})", string.Join(", ", dealerHand), dealerTotal);

			if (dealerTotal > 21)
			{
				Console.WriteLine("DEALER BUSTS!");
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

			Console.WriteLine("\nFINAL HANDS:");
			Console.WriteLine("PLAYER'S HAND {0} (TOTAL: {1}", string.Join(", ", playerHand), playerTotal);
			Console.WriteLine("DEALER'S HAND {0} (TOTAL: {1}", string.Join(", ", dealerHand), dealerTotal);

			if (playerTotal > dealerTotal)
			{
				Console.WriteLine("YOU WIN THIS ROUND!");
				playerScore++;
			}

			else if (dealerTotal > playerTotal)
			{
				Console.WriteLine("DEALER WINS THIS ROUND!");
				dealerScore++;
			}

			else
			{
				Console.WriteLine("TIE!");
			}
		}

		static int DrawCard()
		{
			return random.Next(1, 11);
		}


	}
}
