using System;

namespace weerp.domain.Settings.Messages.Events
{
    public class CreateSettingRejected : SettingBaseRejectedEvent
    {
        public CreateSettingRejected(Guid id, string reason, string code) : base(id, reason, code)
        {
        }
    }
}
