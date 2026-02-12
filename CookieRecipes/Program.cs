using CookieRecipes.FileManager;
using CookieRecipes.Ingredients;

public static class RecipesApp
{
    public static void Main(string[] args)
    {
        FileFormats format = FileFormats.txt;

        List<Ingredient> ingredientList = RecipeDataOutput.LoadIngredients();

        FileReader.DisplayExistingRecipes(format);

        RecipeDataOutput.PrintAllIngredients();

        bool programStart;
        int[] recipe;

        do
        {
            recipe = RecipeDataInput.GetUserSelection(ingredientList.Count, out programStart);
        } while (programStart);

        bool noNewRecipe = ingredientList.Count != 0 && recipe.Length != 0;

        if (noNewRecipe)
        {
            Console.WriteLine("Recipe added!");
            string textForFile = RecipeDataOutput.BuildRecipeString(recipe);

            FileWriter.UpsertFile(format, textForFile);
        }
    }
}