using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Otus.PublicSale.WebApi.Models;

namespace Otus.PublicSale.WebApi.Infostructure
{
    public class AuctionBetValidator: AbstractValidator<AuctionBetDto>
    {
        public AuctionBetValidator()
        {
            this.RuleFor(x => x.AuctionId).NotEmpty();

        }
    }
}
