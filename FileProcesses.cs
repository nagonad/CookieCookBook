using System.Text.Json;

public class FileProcesses
{
    private readonly string path = "savedRecipes.json";
    public void AddRecipe(Recipe recipe)
    {
        var recipes = ReadFromFile();
        recipes.Add(recipe);
        WriterToJsonFile(recipes);
    }

    public List<Recipe> ReadFromFile()
    {

        var newRecipeList = new List<Recipe>();
        string jsonFileContent = File.ReadAllText(path);


        if (jsonFileContent != "")
        {
            var listOfIndexArrays = JsonSerializer.Deserialize<List<List<int>>>(jsonFileContent);
            foreach (var indexArray in listOfIndexArrays)
            {
                var recipe = new Recipe();
                foreach (var index in indexArray)
                {
                    recipe.Add(Recipe.IngredientsList.Find(x => x.ID == index));
                }
                newRecipeList.Add(recipe);
            }
        }


        return newRecipeList;
    }

    public void WriterToJsonFile(List<Recipe> listOfRecipes)
    {

        var listOfIndexes = new List<List<int>>();
        foreach (var recipe in listOfRecipes)
        {
            listOfIndexes.Add(recipe.RecipeToCreate.Select(x => x.ID).ToList());
        }

        var jsonString = JsonSerializer.Serialize(listOfIndexes);
        File.WriteAllText(path, jsonString);

    }

}
