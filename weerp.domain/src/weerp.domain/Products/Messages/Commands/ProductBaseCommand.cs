using System;
using MicroS_Common.Messages;

namespace weerp.domain.Products.Messages.Commands
{
    [MessageNamespace("products")]
    public abstract class ProductBaseCommand : BaseCommand
    {

        public ProductBaseCommand() : base()
        {
        }
    }
}
