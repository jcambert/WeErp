using Newtonsoft.Json;
using System;

namespace weerp.domain.Orders.Messsages.Commands
{
    public class ApproveOrder:OrderBaseCommand
    {

        [JsonConstructor]
        public ApproveOrder(Guid id):base()
        {
            Id = id;
        }

        public override Guid Id { get ; set ; }
    }
}
