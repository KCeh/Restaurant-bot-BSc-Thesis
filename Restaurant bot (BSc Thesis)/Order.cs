using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.Bot.Builder.FormFlow;

namespace Restaurant_bot__BSc_Thesis_
{
    public enum Meals
    {
        Burrito=1,
        Cheeseburger,
        ChickenSandwich,
        FriedChicken,
        Hamburger,
        HotDog,
        Kebab,
        Oatmeal,
        Taco,
        VeggieBurger,
        None
    };

    public enum SaladsAndSnacks
    {
        CaesarSalad=1,
        ChickenSalad,
        MashedPotatoes,
        OnionRings,
        PotatoFries,
        Veggies,
        None
    };

    public enum Drinks
    {
        AppleJuice=1,
        Cappuccino,
        ChocolateMilkshake,
        CokeSoda,
        Espresso,
        IceTea,
        Latte,
        Lemonade,
        Macchiato,
        OrangeJuice,
        None
    };

    public enum Desserts
    {
        ApplePie=1,
        Cheesecake,
        ChocolateCake,
        ChocolateCookies,
        Cupcake,
        IceCream,
        JellyBean,
        LemonBars,
        Pudding,
        Tiramisu,
        None
    };


    [Serializable]
    public class Order
    {
        public Meals Meals;

        public SaladsAndSnacks SaladsAndSnacks;

        public Desserts Desserts;

        public Drinks Drinks;

        public static IForm<Order> BuildForm()
        {
            return new FormBuilder<Order>()
                .Message("Select items you want to order!")
                .Build();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0}, {1}, {2}, {3})", Meals, SaladsAndSnacks, Drinks,
                Desserts);
            return builder.ToString();
        }
    }
}