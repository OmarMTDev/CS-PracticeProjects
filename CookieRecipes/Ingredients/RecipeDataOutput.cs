namespace CookieRecipes.Ingredients
{
using System.Text.Json.Nodes;
    public static class RecipeDataOutput
    {
        public static string GetPreparationById(int Id)
        {
            var ingredientList = LoadIngredients();
            Ingredient? foundIngredient = ingredientList.Find(
                ingredient => ingredient.GetIngredientId().Equals(Id)
            );

            if (foundIngredient is null)
            {
                return "";
            }
            return $"* {foundIngredient.Name} - {foundIngredient.PreparationProcedure}";
        }

        public static List<Ingredient> LoadIngredients()
        {
            var flour = new Ingredient(1, "Flour", "Add a 500g of flour in a bowl.");
            var eggs = new Ingredient(2, "Eggs", "Churn the eggs in a recipient. Mix the eggs with other ingredients.");
            var chocoChips = new Ingredient(3, "Chocolate chips", "Add chips");
            var butter = new Ingredient(4, "Butter", "Melt 200g of butter. Mix the butter with other ingredients.");
            var sugar = new Ingredient(5, "Sugar", "Add 300g of sugar into the mix.");
            var salt = new Ingredient(6, "Salt", "Add a pinch of salt to the mix.");

            return [
                 flour,
                eggs,
                chocoChips,
                butter,
                sugar,
                salt
            ];
        }

        public static void PrintAllIngredients()
        {
            Console.WriteLine("Select an ingredient to build a recipe: ");
            var ingredientList = LoadIngredients();
            foreach (Ingredient item in ingredientList)
            {
                int ingredientId = item.GetIngredientId();
                Console.WriteLine($"Id: {ingredientId} -> {item.Name}");
            }
        }

        public static string BuildRecipeString(int[] recipe)
        {
            return string.Join(",", recipe);
        }

        public static string BuildRecipeJson(int [] recipe)
        {
            string recipeString = "";
            for (int i = 0; i < recipe.Length; i++)
            {
                recipeString += recipe[i].ToString();
                if (i != recipe.Length - 1)
                {
                    recipeString += ", ";
                }
            }
            JsonArray json = new JsonArray(recipeString);
            return json.ToString();
        }
    }
}