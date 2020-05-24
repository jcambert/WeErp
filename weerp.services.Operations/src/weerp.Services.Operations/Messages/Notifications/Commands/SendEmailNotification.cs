using MicroS_Common.Messages;
using Newtonsoft.Json;

namespace MicroS.Services.Operations.Messages.Notifications.Commands
{
    [MessageNamespace("notifications")]
    public class SendEmailNotification : ICommand
    {
        public string Email { get; }
        public string Title { get; }
        public string Message { get; }

        [JsonConstructor]
        public SendEmailNotification(string email, string title, string message)
        {
            Email = email;
            Title = title;
            Message = message;
        }
    }
}
