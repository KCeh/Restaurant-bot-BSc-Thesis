namespace Restaurant_bot__BSc_Thesis_
{
    public class UiFriendlyString
    {
        public string GetMeal(Meals meal)
        {
            switch (meal)
            {
                case Meals.Hamburger: return "Hamburger";
                case Meals.VeggieBurger: return "Veggie Burger";
                case Meals.Burrito: return "Burrito";
                case Meals.Cheeseburger: return "Cheeseburger";
                case Meals.ChickenSandwich: return "Chicken Sandwich";
                case Meals.FriedChicken: return "Fried Chicken";
                case Meals.HotDog: return "Hot Dog";
                case Meals.Kebab: return "Kebab";
                case Meals.Oatmeal: return "Oatmeal";
                case Meals.Taco: return "Taco";
                default: return "";
            }
        }

        public string GetDrinks(Drinks drink)
        {
            switch (drink)
            {
                case Drinks.AppleJuice: return "Apple Juice";
                case Drinks.Cappuccino: return "Cappuccino";
                case Drinks.ChocolateMilkshake: return "Chocolate Milkshake";
                case Drinks.CokeSoda: return "Coke Soda";
                case Drinks.Espresso: return "Espresso";
                case Drinks.IceTea: return "Ice Tea";
                case Drinks.Latte: return "Latte";
                case Drinks.Lemonade: return "Lemonade";
                case Drinks.Macchiato: return "Macchiato";
                case Drinks.OrangeJuice: return "Orange Juice";
                default: return "";
            }
        }

        public string GetSnack(SaladsAndSncks snack)
        {
            switch (snack)
            {
                case SaladsAndSncks.CaesarSalad: return "Caesar Salad";
                case SaladsAndSncks.ChickenSalad: return "Chicken Salad";
                case SaladsAndSncks.MashedPotatoes: return "Mashed Potatoes";
                case SaladsAndSncks.OnionRings: return "Onion Rings";
                case SaladsAndSncks.PotatoFries: return "Potato Fries";
                case SaladsAndSncks.Veggies: return "Veggies";
                default: return "";
            }

        }


        public string GetDessert(Desserts desserts)
        {
            switch (desserts)
            {
                case Desserts.ApplePie: return "Apple Pie";
                case Desserts.Cheesecake: return "Cheesecake";
                case Desserts.ChocolateCake: return "Chocolate Cake";
                case Desserts.ChocolateCookies: return "Chocolate Cookies";
                case Desserts.Cupcake: return "Cupcake";
                case Desserts.IceCream: return "Ice Cream";
                case Desserts.JellyBean: return "Jelly Bean";
                case Desserts.LemonBars: return "Lemon Bars";
                case Desserts.Pudding: return "Pudding";
                case Desserts.Tiramisu: return "Tiramisu";
                default: return "";
            }

        }
}