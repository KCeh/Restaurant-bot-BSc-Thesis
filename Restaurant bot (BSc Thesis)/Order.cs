using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_bot__BSc_Thesis_
{
    // 0 value in enums is reserved for unknown values. 
    public enum Food
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
        CaesarSalad=1,
        ChickenSalad,
        MashedPotatoes,
        OnionRings,
        PotatoFries,
        Veggies
    };

    public enum Drinks
    {
        AppleJuice,
        Cappuccino,
        ChocolateMilkshake,
        CokeSoda,
        Espresso,
        IceTea,
        Latte,
        Lemonade,
        Macchiato,
        OrangeJuice
    };

    public enum Desserts
    {
        ApplePie,
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

    public class Order
    {
    }
}