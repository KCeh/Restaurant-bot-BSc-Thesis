﻿namespace Restaurant_bot__BSc_Thesis_
{
    public class UiFriendlyString
    {
        public static string GetMeal(Meals meal)
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

        public static string GetDrinks(Drinks drink)
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

        public static string GetSnack(SaladsAndSnacks snack)
        {
            switch (snack)
            {
                case SaladsAndSnacks.CaesarSalad: return "Caesar Salad";
                case SaladsAndSnacks.ChickenSalad: return "Chicken Salad";
                case SaladsAndSnacks.MashedPotatoes: return "Mashed Potatoes";
                case SaladsAndSnacks.OnionRings: return "Onion Rings";
                case SaladsAndSnacks.PotatoFries: return "Potato Fries";
                case SaladsAndSnacks.Veggies: return "Veggies";
                default: return "";
            }

        }


        public static string GetDessert(Desserts desserts)
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

        public static string GetMenu(Menus menu)
        {
            switch (menu)
            {
                case Menus.KidsMenu: return "Kids Menu";
                case Menus.OriginalMenu: return "Original Menu";
                case Menus.VegetarianMenu: return "Vegetarian Menu";
                default: return "";
            }
        }
    }
}