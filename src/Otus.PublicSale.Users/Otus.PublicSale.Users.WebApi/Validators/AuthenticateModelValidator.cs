using FluentValidation;
using Otus.PublicSale.Users.WebApi.Models;

namespace Otus.PublicSale.Users.WebApi.Validators
{
    /// <summary>
    /// Authenticate Model Validator
    /// </summary>
    public class AuthenticateModelValidator : AbstractValidator<AuthenticateModel>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AuthenticateModelValidator()
        {            
            RuleFor(x => x.Username)
                .NotNull()
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .Length(0, 50);
        }
    }
}
