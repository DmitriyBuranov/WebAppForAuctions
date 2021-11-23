using FluentValidation;
using Otus.PublicSale.Users.WebApi.Models;

namespace Otus.PublicSale.Users.WebApi.Validators
{
    /// <summary>
    /// Update Model Validator
    /// </summary>
    public class UpdateModelValidator : AbstractValidator<UpdateModel>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UpdateModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .Length(0, 50);

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .Length(0, 50);

            RuleFor(x => x.Username)
                .NotNull()
                .NotEmpty()
                .EmailAddress();
        }
    }
}
