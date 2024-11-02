namespace BlackJackCardGame
{
	internal class Program
	{

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
	}
}
