using MicroS_Common.Types;
using System;

namespace weerp.api.Queries
{
    public class BrowseOrders : PagedQueryBase
    {
        public Guid CustomerId { get; set; }
    }
}
