using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

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

        [LuisIntent("MakeOrder")]
        public async Task Test(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Making order...");
            context.Wait(MessageReceived);
        }

        [LuisIntent("OrderMenu")]
        public async Task Test2(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("menu order...");
            context.Wait(MessageReceived);
        }

        [LuisIntent("WorkingHours")]
        public async Task Test3(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("WorkingHours...");
            context.Wait(MessageReceived);
        }
    }
}