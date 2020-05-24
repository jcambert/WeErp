﻿using MicroS_Common.Messages;
using Newtonsoft.Json;

namespace MicroS.Services.Operations.Messages.Identity.Events
{
    [MessageNamespace("identity")]
    public class SignInRejected : IRejectedEvent
    {
        public string Email { get; }
        public string Reason { get; }
        public string Code { get; }

        [JsonConstructor]
        public SignInRejected(string email, string reason, string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}
