namespace DiceGame
{
    public enum Seasons
    {
        Spring,
        Summer,
        Autumn,
        Winter,
    }

    class Game
    {
        public int Attempts { get; private set; }

        public Game(int attempts)
        {
            Attempts = attempts;
        }

        public void subtractAttempt() => this.Attempts = Attempts -= 1;

        public void printAttempts() => Console.WriteLine($"{Attempts} attempts left.");

        public void Play()
        {
            Dice.ThrowDice();
            do
            {
                Console.WriteLine("**** Dice game ****");
                this.printAttempts();


                Console.Write("Type a number and see if it matches the dice: ");


                var playerInput = Console.ReadLine();
                bool isNumber = int.TryParse(playerInput, out int inputNumber);

                if (!isNumber)
                {
                    GameResponseController.PrintErrorMessage();
                    continue;
                }

                bool playerWins = GameResponseController.CheckIfPlayerWins(inputNumber, Dice.GetDiceValue());

                if (playerWins)
                {
                    GameResponseController.PrintWinMessage();
                    break;
                }

                this.subtractAttempt();
                GameResponseController.PrintRetryMessage();
            } while (this.Attempts != 0);

            if (this.Attempts == 0)
            {
                GameResponseController.PrintGameOver();
            }
        }
    }
}