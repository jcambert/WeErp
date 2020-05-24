using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeErpServicesDiscounts.Metrics
{
    public interface IMetricsRegistry
    {
        void IncrementFindDiscountsQuery();
    }
}
