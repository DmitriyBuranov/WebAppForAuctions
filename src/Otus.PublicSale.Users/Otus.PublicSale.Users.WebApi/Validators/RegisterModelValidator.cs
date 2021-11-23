using FluentValidation;
using Otus.PublicSale.Users.WebApi.Models;

namespace Otus.PublicSale.Users.WebApi.Validators
{
    /// <summary>
    /// Register Model Validator
    /// </summary>
    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RegisterModelValidator()
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

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .Equal(x => x.Password)
                .When(x => !string.IsNullOrWhiteSpace(x.Password))
                .Length(0, 50);
        }
    }
}
