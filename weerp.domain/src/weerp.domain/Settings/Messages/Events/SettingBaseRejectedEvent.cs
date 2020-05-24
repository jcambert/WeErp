using MicroS_Common.Messages;
using System;

namespace weerp.domain.Settings.Messages.Events
{

    [MessageNamespace("settings")]
    public class SettingBaseRejectedEvent : BaseRejectedEvent
    {
        public SettingBaseRejectedEvent(Guid id, string reason, string code) : base(id, reason, code)
        {
        }
    }
}
