using System;
using Microsoft.Bot.Builder.FormFlow;

namespace Restaurant_bot__BSc_Thesis_
{
    public enum Menus
    {
        KidsMenu = 1,
        OriginalMenu,
        VegetarianMenu
    };

    [Serializable]
    public class Menu
    {
        public Menus menu;

        public static IForm<Menu> BuildForm()
        {
            return new FormBuilder<Menu>()
                .Message("Select menu you want to order!")
                .Build();
        }
    }
}