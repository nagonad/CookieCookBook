
public class Recipe
{
    public static List<Ingredient> IngredientsList => new List<Ingredient>() {
    new WheatFlour(),
    new CoconutFlour(),
    new Butter(),
    new Chocolate(),
    new Sugar(),
    new Cardamom(),
    new Cinnamon(),
    new CocoaPowder()
    };

    public List<Ingredient> RecipeToCreate { get; } = new List<Ingredient>();

    public void Add(Ingredient ingredientToAdd)
    {
        RecipeToCreate.Add(ingredientToAdd);
    }
}