using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.Bot.Builder.FormFlow;

namespace Restaurant_bot__BSc_Thesis_
{
    // 0 value in enums is reserved for unknown values. 
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
        VeggieBurger
    };

    public enum SaladsAndSncks
    {
        [Terms(new string[] { "salad" })]
        CaesarSalad =1,
        ChickenSalad,
        MashedPotatoes,
        OnionRings,
        [Terms(new string[] { "fries" })]
        PotatoFries,
        Veggies
    };

    public enum Drinks
    {
        AppleJuice=1,
        Cappuccino,
        ChocolateMilkshake,
        [Terms(new string[] { "coca cola" ,"coke","soda"})]
        CokeSoda,
        [Terms(new string[]{"coffee"})]
        Espresso,
        IceTea,
        Latte,
        Lemonade,
        Macchiato,
        OrangeJuice
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
        Tiramisu
    };


    public enum Menus
    {
        KidsMenu=1,
        OriginalMenu,
        VegetarianMenu
    };

    public enum Coupon
    {
        Menu20Percent = 1,
        HappyHour15Percent
    };

    [Serializable]
    public class Order
    {
        //public orderNumber -doraditi ideju
        //adresa -> dostava za van?
        //implementirati liste

        public Meals Meals;

        [Optional]
        public SaladsAndSncks SaladsAndSncks;

        [Optional]
        public Drinks Drinks;

        [Optional]
        public Desserts Desserts;

        [Optional]
        public Menus Menus;

        [Optional]
        public Coupon Coupon;

        //first simple version
        public static IForm<Order> BuildForm()
        {
            return new FormBuilder<Order>()
                .Message("Welcome to the restaurant order bot!")
                .Build();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            //provjeriti ako je menus null???
            switch (Menus)
            {
                case Menus.KidsMenu:
                    builder.AppendFormat("Order({0}, {1}, {2}, {3})", Meals.ChickenSandwich, Drinks.AppleJuice,
                        Desserts.IceCream,Coupon.Menu20Percent);
                    break;
                case Menus.OriginalMenu:
                    builder.AppendFormat("Order({0}, {1}, {2}, {3})", Meals.Hamburger, Drinks.CokeSoda,
                        Desserts.Cheesecake, Coupon.Menu20Percent);
                    break;
                case Menus.VegetarianMenu:
                    builder.AppendFormat("Order({0}, {1}, {2}, {3})", Meals.VeggieBurger, Drinks.IceTea,
                        Desserts.Cupcake, Coupon.Menu20Percent);
                    break;
                default:
                    builder.AppendFormat("Order({0}, {1}, {2}, {3}, {4})", Meals, SaladsAndSncks, Drinks,
                        Desserts, Coupon);
                    break;
            }
            //ordernumber dodati jos, adresa?
            return builder.ToString();
        }
    }
}