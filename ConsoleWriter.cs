public class ConsoleWriter
{
    private readonly string recipeHeaderFiller = "*****";
    private FileProcesses _fileProcesses;

    public ConsoleWriter(FileProcesses fileProcesses)
    {
        _fileProcesses = fileProcesses;
    }


    public void PrintAllIngredientsOrRecipe(List<Ingredient> ingredients)
    {
        foreach (var ingredient in ingredients)
        {
            PrintSingleIngredient(ingredient);
        }
    }

    public void PrintSingleIngredient(Ingredient ingredient)
    {
        Console.WriteLine($"{ingredient.ID}. {ingredient.Name}");

    }

    public void PrintIfNonExistingIngredientIndexGiven()
    {
        Console.WriteLine("There is no ingredient with given index. Please select a valid ingredient.");

    }

    public void PrintIFNoIngredientInList()
    {

        Console.WriteLine("You have added 0 ingredient to recipe. There is nothing to save.");
    }

    internal void PrintAllExistingRecipes()
    {
        var recipeList = _fileProcesses.ReadFromFile();
        for (int i = 0; i < recipeList.Count; i++)
        {
            Console.WriteLine(recipeHeaderFiller + " " + (i + 1) + " " + recipeHeaderFiller);
            PrintAllIngredientsOrRecipe(recipeList[i].RecipeToCreate);
        }
    }

    //public void PrintRecipe(Recipe recipe, int index)
    //{
    //    Console.WriteLine(recipeHeaderFiller + index + recipeHeaderFiller);
    //    foreach (var item in recipe.)
    //    {

    //    }
    //}
}