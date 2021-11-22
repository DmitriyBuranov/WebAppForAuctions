using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Otus.PublicSale.WebApi.Models;

namespace Otus.PublicSale.WebApi.Infostructure
{
    public class AuctionValidator: AbstractValidator<AuctionDto>
    {
        public AuctionValidator()
        {
            this.RuleFor(x => x.EndDate).NotEmpty();
            this.RuleFor(x => x.PriceStart).NotEmpty();
            this.RuleFor(x => x.PriceStep).NotEmpty();
        }
    }
}
