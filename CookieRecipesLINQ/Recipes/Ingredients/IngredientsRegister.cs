namespace CookieCookbook.Recipes.Ingredients;

public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
        new WheatFlour(),
        new SpeltFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder()
    };

    public Ingredient GetById(int id)
    {
        // Exercise of removing duplications.
        // if(All.Select(ingred => ingred.Id).Distinct().Count() != All.Count())
        // {
        //     throw new InvalidOperationException("There are duplicated Ids in this list.");
        // }

        return All
         .FirstOrDefault(ingredient => ingredient.Id == id);
    }

}

