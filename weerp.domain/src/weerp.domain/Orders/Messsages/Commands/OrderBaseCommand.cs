using MicroS_Common.Messages;

namespace weerp.domain.Orders.Messsages.Commands
{

    [MessageNamespace("orders")]
    public abstract class OrderBaseCommand : BaseCommand
    {

        public OrderBaseCommand() : base()
        {

        }
    }
}