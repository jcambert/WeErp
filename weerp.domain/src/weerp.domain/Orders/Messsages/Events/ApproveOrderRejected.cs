using System;

namespace weerp.domain.Orders.Messsages.Events
{

    public class ApproveOrderRejected : OrderBaseRejectedEvent
    {


        public ApproveOrderRejected(Guid id, string reason, string code) : base(id, reason, code)
        {

        }
    }
}
