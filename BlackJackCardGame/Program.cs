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
