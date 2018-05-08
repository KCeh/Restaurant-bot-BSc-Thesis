using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;
using Restaurant_bot__BSc_Thesis_.Dialogs;

namespace Restaurant_bot__BSc_Thesis_.Controllers
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        internal static IDialog<Order> MakeRootDialog()
        {
            return Chain.From(() => new OrderDialog());
        }

        [ResponseType(typeof(void))]
        public virtual async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {
            if (activity != null)
            {
                switch (activity.GetActivityType())
                {
                    case ActivityTypes.Message:
                        await Conversation.SendAsync(activity, MakeRootDialog);
                        break;

                    case ActivityTypes.ConversationUpdate:
                         
                        IConversationUpdateActivity update = activity;
                        var client = new ConnectorClient(new Uri(activity.ServiceUrl), new MicrosoftAppCredentials());
                        if (update.MembersAdded != null && update.MembersAdded.Any())
                        {
                            foreach (var newMember in update.MembersAdded)
                            {
                                if (newMember.Id != activity.Recipient.Id)
                                {
                                    if (newMember.Name == null)
                                        newMember.Name = "User";
                                    var reply = activity.CreateReply();
                                    reply.Text = $"Welcome {newMember.Name}, I'm restaurant bot!";
                                    await client.Conversations.ReplyToActivityAsync(reply);
                                }
                            }
                        }
                        break;
                    case ActivityTypes.ContactRelationUpdate:
                        HandleSystemMessage(activity);
                        break;
                    case ActivityTypes.Typing:
                        HandleSystemMessage(activity);
                        break;
                    case ActivityTypes.DeleteUserData:
                        HandleSystemMessage(activity);
                        break;
                    default:
                        Trace.TraceError($"Unknown activity type ignored: {activity.GetActivityType()}");
                        break;
                }

            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }
            return null;
        }
    }
}