namespace CookieRecipes.Ingredients
{
    static class RecipeDataInput
    {
        static List<int> UserInputs { get; set; } = new List<int>();
        public static int[] GetUserSelection(int maxIngredientsId, out bool programRunning)
        {
            programRunning = true;
            Console.WriteLine("Select an id to add the ingredient. Type anything else to end.");
            var input = Console.ReadLine();

            bool parsedCorrectly = int.TryParse(input, out int selectedId);

            if (!parsedCorrectly)
            {
                programRunning = false;
                return GetInputsAsArray();
            }

            if (selectedId <= maxIngredientsId)
            {
                UserInputs.Add(selectedId);
                return GetInputsAsArray();
            }
            Console.WriteLine("Invalid input");
            programRunning = true;
            return GetInputsAsArray();
        }

        public static int[] GetInputsAsArray()
        {
            if (UserInputs.Count == 0)
            {
                Console.WriteLine("Ingredient list is empty. Aborting file generation.");
            }
            return [.. UserInputs];
        }
    }
}