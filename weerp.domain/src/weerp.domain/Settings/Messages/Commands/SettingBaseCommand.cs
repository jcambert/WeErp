using MicroS_Common.Messages;

namespace weerp.domain.Settings.Messages.Commands
{


    [MessageNamespace("settings")]
    public abstract class SettingBaseCommand : BaseCommand
    {

        public SettingBaseCommand() : base()
        {
        }
    }
}
