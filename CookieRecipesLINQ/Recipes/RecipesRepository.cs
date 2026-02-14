using CookieCookbook.DataAccess;
using CookieCookbook.Recipes.Ingredients;

namespace CookieCookbook.Recipes;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;
    private readonly IIngredientsRegister _ingredientsRegister;
    private const string Separator = ",";

    public RecipesRepository(
        IStringsRepository stringsRepository,
        IIngredientsRegister ingredientsRegister)
    {
        _stringsRepository = stringsRepository;
        _ingredientsRegister = ingredientsRegister;
    }

    public List<Recipe> Read(string filePath)
    {
        List<string> recipesFromFile = _stringsRepository.Read(filePath);
        var recipes = new List<Recipe>();

        foreach (var recipeFromFile in recipesFromFile)
        {
            var recipe = RecipeFromString(recipeFromFile);
            recipes.Add(recipe);
        }

        return recipes;
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var ingredients = recipeFromFile.Split(Separator)
          .Select(int.Parse)
          .Select(_ingredientsRegister.GetById);

        return new Recipe(ingredients);
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        /* Simpler
        var recipesAsStrings = allRecipes
        .Select(recipe => string.Join(
            Separator, recipe.Ingredients.Select(ingredient => ingredient.Id))
        );
        */

        //Better readability
        var recipesAsStrings = allRecipes
        .Select(recipe =>
       {
           var allIds = recipe.Ingredients
           .Select(ingredient => ingredient.Id);
           return string.Join(
            Separator, allIds);
       });



        _stringsRepository.Write(filePath, recipesAsStrings.ToList());
    }
}
