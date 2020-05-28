using MicroS_Common.Domain;
using MicroS_Common.Types;
using Microsoft.Extensions.Localization;
using System;

using weerp.domain.Products.Domain;

namespace weerp.domain.Products.Validators
{
    public class Validate : IValidate<Product>
    {
        private readonly IStringLocalizer<Product> _localizer;
        private readonly IValidateContext _context;

        public Validate(IStringLocalizer<Product> localizer,IValidateContext context)
        {
            _localizer = localizer;
            _context = context;
        }
        public void IsValide(Product model)
        {
            
            model.Validate(ref model._name,model=> model.Name?.Trim()?.ToLowerInvariant(), string.IsNullOrEmpty, "empty_product_name", _localizer["empty_product_name"], _context);
            if (!_context.IsValid)
                throw new MicroSException("validation", _context);
        
        }
    }
}
