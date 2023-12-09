public class ApplicationFlow
{
    public void Start()
    {
        //print existing saved recipe from file
        var fileProcesser = new FileProcesses();
        var consoleWriter = new ConsoleWriter(fileProcesser);
        Console.WriteLine("Existing recipes are:");
        consoleWriter.PrintAllExistingRecipes();


        Console.WriteLine("Create a new cookie recipe! Availible ingredients are:");
        var recipe = new Recipe();
        consoleWriter.PrintAllIngredientsOrRecipe(Recipe.IngredientsList);

        do
        {
            Console.WriteLine("Add an ingredient by it's Id or type anthing else if finished.");
            var userInput = Console.ReadLine();
            int result = 0;
            bool checkIfParseable = int.TryParse(userInput, out result);
            if (!checkIfParseable)
            {

                //if list is empty no ingredients saved notification

                if (recipe.RecipeToCreate.Count < 1)
                {
                    consoleWriter.PrintIFNoIngredientInList();
                }
                else
                {
                    //print existing recipe
                    Console.WriteLine("Saved Recipe:");
                    consoleWriter.PrintAllIngredientsOrRecipe(recipe.RecipeToCreate);

                    //save recipe to the text file
                    fileProcesser.AddRecipe(recipe);
                }

                break;
            }
            if (result < Recipe.IngredientsList.Count + 1 && result > 0)
            {
                //add item to recipe
                var ingredient = Recipe.IngredientsList.Find(x => x.ID == result);
                Console.Write("Added ingredient: ");
                consoleWriter.PrintSingleIngredient(ingredient);
                recipe.Add(ingredient);


            }
            else
            {
                //notification for not being added any ingredient
                consoleWriter.PrintIfNonExistingIngredientIndexGiven();
                Console.WriteLine("--------");
            }

        } while (true);
    }


}
