using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programming_poe_part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();
            List<Recipe> recipes = new List<Recipe>(); // use a list to store recipes 

            while (true)
            {

                // Set the console text color to orange
                Console.ForegroundColor = ConsoleColor.DarkYellow;

               //display the main menu 
                Console.WriteLine("\nWelcome to Recipe App!\n");
                Console.WriteLine("Please select an option:\n");
                Console.WriteLine("1. Enter a new recipe");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Scale a recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear all data");
                Console.WriteLine("6. Exit\n");


                // Reset the console text color to default
                Console.ResetColor();
                Console.Write("Enter your choice (1-6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {

                    // Call the corresponding method based on user choice
                    case "1":
			Recipe newRecipe = new Recipe (); //create a new recipe object
                        newRecipe.EnterDetails();
                        recipes.Add(newRecipe);
                        break;

                    case "2":
			// Display all recipe in alphabetical order
                        if (recipes.Count == 0)
                        {
                            Console.WriteLine("\nNo recipes found.");
                        }
                        else
                        {
			   List<Recipe> sortedrecipes = recipes.OrderBy(r => r.Name).ToList();
                           
                            Console.WriteLine("\nList of all recipes:\n");
                            foreach (Recipe r in sortedRecipes)
                            {
                                Console.WriteLine(r.Name);
                            }

                            Console.Write("\nEnter the name of the recipe you want to display: ");
                            string recipeName = Console.ReadLine();
                            Recipe selectedRecipe = sortedRecipes.Find(r => r.Name.ToLower() == recipeName.ToLower());
                            if (selectedRecipe == null)
                            {
                                Console.WriteLine("\nRecipe not found.");
                            }
                            else
                            {
                                selectedRecipe.Display();
                            }
                        }
                        break;

                    case "3":

			//Scale a recipe

            Console.Write("Enter the name of the recipe you want to rest quantities for: ");
			string recipeToScale = Console.ReadLine();
			Recipe recipe = recipes.Find(r=> r.Name.ToLower() == recipeToScale.ToLower());

			if (recipe == null)

			{
				Console.WriteLine("\nRecipe not found.");
			}
			 else
			{
				recipe.Scale();
			}

                        break;

                    case "4":

			//Reset quantities of a recipe
			Console.Write("Enter the name of the recipe you want to rest quantities for: ");
			string recipeToReset = Console.ReadLine();
			Recipe resetRecipe = recipes. Find(r => r.Name.ToLower() == recipeToReset.ToLower());
                    if(resetRecipe == null)
			{
				Console.WriteLine("\nRecipe not found.");
			}
			else
			{
				resetRecipe.ResetQuantities();
			}

                        break;

                    case "5":
 			//Clear all adata of a recipe
			Console.Write("Enter the name of the recipe you want to clear data for: ")
			string recipeToClear = Console.ReadLine();
			Recipe clearRecipe = recipes.Find(r => r.Name.ToLower() == recipeToClear.ToLower());
                        if(clearRecipe == null)
			{
                        	Console.WriteLine("\nRecipe not found.");
			}
			else
			{
				clearRecipe.ClearData();
			}
			break;

                    case "6":
			//Exit the application
                        Environment.Exit(0);
                        break;

                    	default:
			//Displayed for an invalid choice
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine();
            }
        }

        class Recipe
        {
            private List <Ingredient> ingredients = new List<Ingredient>(); // use a list to store ingredients
            private List <string> steps = new List<string>(); // use a list to store steps
            


            public string Name { get; set; }
            public double TotalCalories { get; private set; }
           

            public void EnterDetails()
 {
		// Enter details for a new recipe

                Console.Write("Enter the name of the recipe: ");
                Name = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Enter the number of ingredients: ");
                int numIngredients = int.Parse(Console.ReadLine());
                Console.WriteLine();

                // Create arrays to store ingredients and their orginal quantities 


                for (int i = 0; i < numIngredients; i++)
		{

		// Enter details for each ingredient
                    Console.WriteLine($"Ingredient {i + 1}:");
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Quantity: ");
                    double quantity = double.Parse(Console.ReadLine());
                    Console.Write("Unit of measurement: ");
                    string unit = Console.ReadLine();
                    Console.Write("Calories: ");
                    double calories = double.Parse(Console.ReadLine());
                    Console.Write("Food Group: ");
                    string foodGroup = Console.ReadLine();
                    Console.WriteLine();

                    // Add the ingredient to the arrays 

                    ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup);
                    
                    TotalCalories += calories;
                }

                Console.Write("Enter the number of steps: ");
                int numSteps = int.Parse(Console.ReadLine());
                Console.WriteLine();

                // Create an array that will store the steps

               

                // Enter each step

                for (int i = 0; i < numSteps; i++)
                {
                    Console.WriteLine($"Step {i + 1}:");
                    string step = Console.ReadLine();
                    steps[i] = step;
                    Console.WriteLine();
                }
            }

            public void Display()
            {
                // Displaying all the recipe details 
                Console.WriteLine($"Recipe name: {Name}");
                Console.WriteLine("Ingredients : ");


                foreach (Ingredient ingredient in ingredients)
                {
                    Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name}");
                }

                Console.WriteLine();
                Console.WriteLine("Steps: ");
                for (int i = 0; i < steps.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {steps[i]}");
                }

                Console.WriteLine();
                Console.WriteLine($"Total Calories: {TotalCalories}");

                if (TotalCalories > 300)
                {
                    Console.WriteLine("Warning: Total calories exceed 300!");
                }
            }



            public void Scale()
            {
		//Scale the quantities of ingredients in the recipe

                Console.Write("Enter scaling factor (0.5, 2, or 3): ");//prompt the user to enter the scale factors
                double factor = double.Parse(Console.ReadLine());
                Console.WriteLine();
                
                {

                    foreach (Ingredient ingredient in ingredients);

                    double newQuantity = ingredient.Quantity * factor;
                    Ingredient.Quantity = newQuantity;
                }
            }

            public void ResetQuantities()
            {
                //reset the quantities
                foreach (Ingredient ingredient in ingredients )
                {
                    
                    ingredient.ResetQuantity();
                }
            }

            public void ClearData()
            {
		// Clear all data of the recipe 
                //clearing all the data entered by the user
                ingredients.Clear();
                steps.Clear();
                
            }


        }

    }


}


