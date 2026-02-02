namespace DiceGame
{
    static class Dice
    {
        private const int _minDiceValue = 1;
        private const int _maxDiceValue = 6;
        private static int DiceValue;
    
        public static void ThrowDice() => DiceValue = new Random().Next(_minDiceValue, _maxDiceValue);

        public static int GetDiceValue()=> DiceValue;
    }
}