using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Otus.PublicSale.WebApi.Models;

namespace Otus.PublicSale.WebApi.Infostructure
{
    public class AuctionUserValidator: AbstractValidator<AuctionUserDto>
    {
        public AuctionUserValidator()
        {
            this.RuleFor(x => x.AuctionId).NotEmpty();
            this.RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
