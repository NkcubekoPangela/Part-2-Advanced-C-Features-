namespace programming_poe_part2
{
    internal class Ingredient
    {
        private string name {get; set; };
        private double quantity {get; set; };
        private string unit {get; set; };
        private double calories {get; set; };
        private string foodGroup {get; set; };

	//Constructor to initialize the ingredient

        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
          Name = name;
          Quantity = quantity;
          Unit = unit;
          Calories = calories;
          FoodGroup = foodGroup;
        }
	public void ResetQuantity()

	{
		//reset quantity to original value 
}
    }
}