using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace Restaurant_bot__BSc_Thesis_.Dialogs
{
    [LuisModel("4bdcdf2d-c797-4355-9003-6ab486c91460", "88c34c414eec43d3ab3f068892db86f1", LuisApiVersion.V2, domain: "westeurope.api.cognitive.microsoft.com")]
    [Serializable]
    public class OrderDialog:LuisDialog<Order>
    {     
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I'm sorry. I didn't understand you.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Food")]
        public async Task Food(IDialogContext dialogContext, LuisResult luisResult)
        {
            var dialog = FormDialog.FromForm(Restaurant_bot__BSc_Thesis_.Order.BuildForm,
                options: FormOptions.PromptInStart);

            dialogContext.Call(dialog,
                async (context, result) =>
                {
                    try
                    {
                        var order = await result;

                        var status = context.MakeMessage();
                        status.Type = ActivityTypes.Message;

                        List<ReceiptItem> receiptList = new List<ReceiptItem>();
                        ReceiptItem lineItem1 = new ReceiptItem()
                        {
                            Title = UiFriendlyString.GetMeal(order.Meals)
                        };
                        if (lineItem1.Title != "")
                            receiptList.Add(lineItem1);

                        if (order.SaladsAndSnacks != 0)
                        {
                            ReceiptItem lineItem2 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetSnack(order.SaladsAndSnacks)
                            };
                            if (lineItem2.Title != "")
                                receiptList.Add(lineItem2);
                        }

                        if (order.Drinks != 0)
                        {
                            ReceiptItem lineItem3 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetDrinks(order.Drinks)
                            };
                            if (lineItem3.Title != "")
                                receiptList.Add(lineItem3);
                        }

                        if (order.Desserts != 0)
                        {
                            ReceiptItem lineItem4 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetDessert(order.Desserts)
                            };
                            if (lineItem4.Title != "")
                                receiptList.Add(lineItem4);
                        }

                        if (order.Meals == Meals.Cheeseburger && order.Drinks == Drinks.CokeSoda
                                                              && order.SaladsAndSnacks == SaladsAndSnacks.PotatoFries)
                        {
                            ReceiptItem lineItem5 = new ReceiptItem()
                            {
                                Title = "Discount worth 15%"
                            };
                            receiptList.Add(lineItem5);
                        }


                        ReceiptCard plCard = new ReceiptCard()
                        {
                            Title = "Thanks for placing order. Your order is: ",
                            Items = receiptList,

                            //if DB is added, add code here
                        };

                        Attachment plAttachment = plCard.ToAttachment();
                        status.Attachments.Add(plAttachment);

                        await context.PostAsync(status);
                    }
                    catch (FormCanceledException<Order> ex)
                    {
                        string reply;
                        if (ex.InnerException == null)
                        {
                            reply = $"You quit on {ex.Last} -- maybe you can finish next time!";
                        }
                        else
                        {
                            reply = $"Sorry, I've had a short circuit. Please try again.{ex.StackTrace}";
                        }
                        await context.PostAsync(reply);
                    }
                    context.Wait(MessageReceived);
                });
        }
        [LuisIntent("Salad")]
        public async Task Salad(IDialogContext dialogContext, LuisResult luisResult)
        {
            Order state = new Order();
            state.Meals = Meals.None;//not needed
            var dialog = new FormDialog<Order>(state, Order.BuildForm, FormOptions.PromptInStart);

            dialogContext.Call(dialog,
                async (context, result) =>
                {
                    try
                    {
                        var order = await result;

                        var status = context.MakeMessage();
                        status.Type = ActivityTypes.Message;

                        List<ReceiptItem> receiptList = new List<ReceiptItem>();
                        ReceiptItem lineItem1 = new ReceiptItem()
                        {
                            Title = UiFriendlyString.GetMeal(order.Meals)
                        };
                        if (lineItem1.Title != "")
                            receiptList.Add(lineItem1);

                        if (order.SaladsAndSnacks != 0)
                        {
                            ReceiptItem lineItem2 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetSnack(order.SaladsAndSnacks)
                            };
                            if (lineItem2.Title != "")
                                receiptList.Add(lineItem2);
                        }

                        if (order.Drinks != 0)
                        {
                            ReceiptItem lineItem3 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetDrinks(order.Drinks)
                            };
                            if (lineItem3.Title != "")
                                receiptList.Add(lineItem3);
                        }

                        if (order.Desserts != 0)
                        {
                            ReceiptItem lineItem4 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetDessert(order.Desserts)
                            };
                            if (lineItem4.Title != "")
                                receiptList.Add(lineItem4);
                        }

                        if (order.Meals == Meals.Cheeseburger && order.Drinks == Drinks.CokeSoda
                                                              && order.SaladsAndSnacks == SaladsAndSnacks.PotatoFries)
                        {
                            ReceiptItem lineItem5 = new ReceiptItem()
                            {
                                Title = "Discount worth 15%"
                            };
                            receiptList.Add(lineItem5);
                        }


                        ReceiptCard plCard = new ReceiptCard()
                        {
                            Title = "Thanks for placing order. Your order is: ",
                            Items = receiptList,

                            //if DB is added, add code here
                        };

                        Attachment plAttachment = plCard.ToAttachment();
                        status.Attachments.Add(plAttachment);

                        await context.PostAsync(status);
                    }
                    catch (FormCanceledException<Order> ex)
                    {
                        string reply;
                        if (ex.InnerException == null)
                        {
                            reply = $"You quit on {ex.Last} -- maybe you can finish next time!";
                        }
                        else
                        {
                            reply = $"Sorry, I've had a short circuit. Please try again.{ex.StackTrace}";
                        }
                        await context.PostAsync(reply);
                    }
                    context.Wait(MessageReceived);
                });
        }

        [LuisIntent("Drink")]
        public async Task Drink(IDialogContext dialogContext, LuisResult luisResult)
        {
            Order state = new Order();
            state.Meals = Meals.None;//not needed
            state.SaladsAndSnacks=SaladsAndSnacks.None;
            state.Desserts = Desserts.None;
            var dialog  = new FormDialog<Order>(state, Order.BuildForm, FormOptions.PromptInStart);

            dialogContext.Call(dialog,
                async (context, result) =>
                {
                    try
                    {
                        var order = await result;

                        var status = context.MakeMessage();
                        status.Type = ActivityTypes.Message;

                        List<ReceiptItem> receiptList = new List<ReceiptItem>();
                        ReceiptItem lineItem1 = new ReceiptItem()
                        {
                            Title = UiFriendlyString.GetMeal(order.Meals)
                        };
                        if(lineItem1.Title!="")
                            receiptList.Add(lineItem1);

                        if (order.SaladsAndSnacks != 0)
                        {
                            ReceiptItem lineItem2 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetSnack(order.SaladsAndSnacks)
                            };
                            if (lineItem2.Title != "")
                                receiptList.Add(lineItem2);
                        }

                        if (order.Drinks != 0)
                        {
                            ReceiptItem lineItem3 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetDrinks(order.Drinks)
                            };
                            if (lineItem3.Title != "")
                                receiptList.Add(lineItem3);
                        }

                        if (order.Desserts != 0)
                        {
                            ReceiptItem lineItem4 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetDessert(order.Desserts)
                            };
                            if (lineItem4.Title != "")
                                receiptList.Add(lineItem4);
                        }

                        if (order.Meals == Meals.Cheeseburger && order.Drinks == Drinks.CokeSoda
                                                              && order.SaladsAndSnacks == SaladsAndSnacks.PotatoFries)
                        {
                            ReceiptItem lineItem5 = new ReceiptItem()
                            {
                                Title = "Discount worth 15%"
                            };
                            receiptList.Add(lineItem5);
                        }


                        ReceiptCard plCard = new ReceiptCard()
                        {
                            Title = "Thanks for placing order. Your order is: ",
                            Items = receiptList,

                            //if DB is added, add code here
                        };

                        Attachment plAttachment = plCard.ToAttachment();
                        status.Attachments.Add(plAttachment);

                        await context.PostAsync(status);
                    }
                    catch (FormCanceledException<Order> ex)
                    {
                        string reply;
                        if (ex.InnerException == null)
                        {
                            reply = $"You quit on {ex.Last} -- maybe you can finish next time!";
                        }
                        else
                        {
                            reply = $"Sorry, I've had a short circuit. Please try again.{ex.StackTrace}";
                        }
                        await context.PostAsync(reply);
                    }
                    context.Wait(MessageReceived);
                });
        }

        [LuisIntent("Dessert")]
        public async Task Dessert(IDialogContext dialogContext, LuisResult luisResult)
        {
            Order state = new Order();
            state.Meals = Meals.None;//not needed
            state.SaladsAndSnacks = SaladsAndSnacks.None;
            var dialog = new FormDialog<Order>(state, Order.BuildForm, FormOptions.PromptInStart);

            dialogContext.Call(dialog,
                async (context, result) =>
                {
                    try
                    {
                        var order = await result;

                        var status = context.MakeMessage();
                        status.Type = ActivityTypes.Message;

                        List<ReceiptItem> receiptList = new List<ReceiptItem>();
                        ReceiptItem lineItem1 = new ReceiptItem()
                        {
                            Title = UiFriendlyString.GetMeal(order.Meals)
                        };
                        if (lineItem1.Title != "")
                            receiptList.Add(lineItem1);

                        if (order.SaladsAndSnacks != 0)
                        {
                            ReceiptItem lineItem2 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetSnack(order.SaladsAndSnacks)
                            };
                            if (lineItem2.Title != "")
                                receiptList.Add(lineItem2);
                        }

                        if (order.Drinks != 0)
                        {
                            ReceiptItem lineItem3 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetDrinks(order.Drinks)
                            };
                            if (lineItem3.Title != "")
                                receiptList.Add(lineItem3);
                        }

                        if (order.Desserts != 0)
                        {
                            ReceiptItem lineItem4 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetDessert(order.Desserts)
                            };
                            if (lineItem4.Title != "")
                                receiptList.Add(lineItem4);
                        }

                        if (order.Meals == Meals.Cheeseburger && order.Drinks == Drinks.CokeSoda
                                                              && order.SaladsAndSnacks == SaladsAndSnacks.PotatoFries)
                        {
                            ReceiptItem lineItem5 = new ReceiptItem()
                            {
                                Title = "Discount worth 15%"
                            };
                            receiptList.Add(lineItem5);
                        }


                        ReceiptCard plCard = new ReceiptCard()
                        {
                            Title = "Thanks for placing order. Your order is: ",
                            Items = receiptList,

                            //if DB is added, add code here
                        };

                        Attachment plAttachment = plCard.ToAttachment();
                        status.Attachments.Add(plAttachment);

                        await context.PostAsync(status);
                    }
                    catch (FormCanceledException<Order> ex)
                    {
                        string reply;
                        if (ex.InnerException == null)
                        {
                            reply = $"You quit on {ex.Last} -- maybe you can finish next time!";
                        }
                        else
                        {
                            reply = $"Sorry, I've had a short circuit. Please try again.{ex.StackTrace}";
                        }
                        await context.PostAsync(reply);
                    }
                    context.Wait(MessageReceived);
                });
        }

        [LuisIntent("OrderMenu")]
        public Task Menu(IDialogContext dialogContext, LuisResult luisResult)
        {
            var dialog = FormDialog.FromForm(Restaurant_bot__BSc_Thesis_.Menu.BuildForm,
                options: FormOptions.PromptInStart);

            dialogContext.Call(dialog,
                async (context, result) =>
                {
                    try
                    {
                        var menuOrder = await result;

                        var status = context.MakeMessage();
                        status.Type = ActivityTypes.Message;

                        List<ReceiptItem> receiptList = new List<ReceiptItem>();
                        ReceiptItem lineItem1 = new ReceiptItem()
                        {
                            Title = UiFriendlyString.GetMenu(menuOrder.menu) + " that contains:"
                        };
                        receiptList.Add(lineItem1);

                        if (menuOrder.menu == Menus.KidsMenu)
                        {
                            ReceiptItem lineItem2 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetMeal(Meals.Hamburger)
                            };
                            receiptList.Add(lineItem2);
                        }
                        else if (menuOrder.menu == Menus.OriginalMenu)
                        {
                            ReceiptItem lineItem2 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetMeal(Meals.Cheeseburger)
                            };
                            receiptList.Add(lineItem2);
                        }
                        else if (menuOrder.menu == Menus.VegetarianMenu)
                        {
                            ReceiptItem lineItem2 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetMeal(Meals.VeggieBurger)
                            };
                            receiptList.Add(lineItem2);
                        }

                        if (menuOrder.menu == Menus.KidsMenu)
                        {
                            ReceiptItem lineItem3 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetSnack(SaladsAndSnacks.OnionRings)
                            };
                            receiptList.Add(lineItem3);
                        }
                        else if (menuOrder.menu == Menus.OriginalMenu)
                        {
                            ReceiptItem lineItem3 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetSnack(SaladsAndSnacks.PotatoFries)
                            };
                            receiptList.Add(lineItem3);
                        }
                        else if (menuOrder.menu == Menus.VegetarianMenu)
                        {
                            ReceiptItem lineItem3 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetSnack(SaladsAndSnacks.Veggies)
                            };
                            receiptList.Add(lineItem3);
                        }


                        if (menuOrder.menu == Menus.KidsMenu)
                        {
                            ReceiptItem lineItem4 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetDrinks(Drinks.AppleJuice)
                            };
                            receiptList.Add(lineItem4);
                        }
                        else if (menuOrder.menu == Menus.OriginalMenu)
                        {
                            ReceiptItem lineItem4 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetDrinks(Drinks.CokeSoda)
                            };
                            receiptList.Add(lineItem4);
                        }
                        else if (menuOrder.menu == Menus.VegetarianMenu)
                        {
                            ReceiptItem lineItem4 = new ReceiptItem()
                            {
                                Title = UiFriendlyString.GetDrinks(Drinks.OrangeJuice)
                            };
                            receiptList.Add(lineItem4);
                        }

                        ReceiptItem lineItem5 = new ReceiptItem()
                        {
                            Title = "Discount worth 15% for ordering menu"
                        };
                        receiptList.Add(lineItem5);



                        ReceiptCard plCard = new ReceiptCard()
                        {
                            Title = "Thanks for placing order. Your order is: ",
                            Items = receiptList,

                            //if DB is added, add code here
                        };

                        Attachment plAttachment = plCard.ToAttachment();
                        status.Attachments.Add(plAttachment);

                        await context.PostAsync(status);
                    }
                    catch (FormCanceledException<Menu> ex)
                    {
                        string reply;
                        if (ex.InnerException == null)
                        {
                            reply = $"You quit on {ex.Last} -- maybe you can finish next time!";
                        }
                        else
                        {
                            reply = $"Sorry, I've had a short circuit. Please try again.{ex.StackTrace}";
                        }
                        await context.PostAsync(reply);
                    }

                    context.Wait(MessageReceived);
                });

            return Task.CompletedTask;
        }

        [LuisIntent("WorkingHours")]
        public async Task WorkingHours(IDialogContext context, LuisResult result)
        { 
            await context.PostAsync("The restaurant is open from 9:00 to 24:00, every day of the week.");
            await context.PostAsync("But I'm available anytime ;)");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Help")]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("This is restaurant bot for ordering food and drinks! ");
            var reply = context.MakeMessage();
            reply.Type = ActivityTypes.Message;

            List<CardAction> cardButtons = new List<CardAction>();
            cardButtons.Add(new CardAction() { Title = "Order meal", Type = ActionTypes.ImBack, Value = "food" });
            cardButtons.Add(new CardAction() { Title = "Order snack or salad", Type = ActionTypes.ImBack, Value = "snack" });
            cardButtons.Add(new CardAction() { Title = "Order drink", Type = ActionTypes.ImBack, Value = "drink" });
            cardButtons.Add(new CardAction() { Title = "Order dessert", Type = ActionTypes.ImBack, Value = "dessert" });
            cardButtons.Add(new CardAction() { Title = "Order menu", Type = ActionTypes.ImBack, Value = "menu" });
            cardButtons.Add(new CardAction() { Title = "Open hours", Type = ActionTypes.ImBack, Value = "hours" });
            HeroCard plCard = new HeroCard()
            {
                Title = "Click on one suggested action to continue",
                Buttons = cardButtons,
            };

            Attachment plAttachment = plCard.ToAttachment();
            reply.Attachments.Add(plAttachment);

            await context.PostAsync(reply);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Hello")]
        public async Task Hello(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("![bot](https://pbs.twimg.com/profile_images/833180315153608704/g_LAHGXB_400x400.jpg)");
            await context.PostAsync("Hi I'm restaurant bot!");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Thanks")]
        public async Task Thanks(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("You're welcome");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Coupon")]
        public async Task Coupon(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("You can get discount by ordering menus or by selecting Cheeseburger, Potato Fries and Coke Soda while making order");
            context.Wait(MessageReceived);
        }
    }
}