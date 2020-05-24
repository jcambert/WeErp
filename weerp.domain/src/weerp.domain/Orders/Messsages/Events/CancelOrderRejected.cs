using System;
using System.Collections.Generic;
using System.Text;

namespace weerp.domain.Orders.Messsages.Events
{

    public class CancelOrderRejected : OrderBaseRejectedEvent
    {
 
        public Guid CustomerId { get; }

        public CancelOrderRejected(Guid id, string reason, string code, Guid customerId):base(id,reason,code)
        {
            CustomerId = customerId;
        }
    }
}
