namespace DiceGame
{
    class GameResponseController
    {
        public static bool CheckIfPlayerWins(int playerInput, int diceValue)
        {
            bool win = false;
            if (playerInput == Dice.GetDiceValue())
            {
                win = true;
            }
            return win;
        }

        public static void PrintWinMessage()
        {
            Console.Write("You won!.");
            Console.Write("Press any key to exit.");
        }

        public static void PrintRetryMessage() => Console.WriteLine("Bad guess!");

        public static void PrintErrorMessage()
        {
            Console.WriteLine("Invalid input. Please try again.");
        }

        public static void PrintGameOver()
        {
            Console.WriteLine("You have lost.");
            Console.WriteLine("Game over. Press any key to exit.");
            Console.ReadKey();
        }
    }
}