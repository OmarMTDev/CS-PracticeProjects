namespace CookieRecipes.Ingredients
{
    public class Ingredient(int id, string name, string procedure)
    {
        private int Id { get; init; } = id;
        public string Name { get; set; } = name;
        public string PreparationProcedure { get; set; } = procedure;

        public int GetIngredientId()
        {
            return Id;
        }
    }
}