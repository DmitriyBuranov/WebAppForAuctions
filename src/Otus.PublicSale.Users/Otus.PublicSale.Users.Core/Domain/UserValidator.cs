using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.PublicSale.Users.Core.Domain
{
	/// <summary>
	/// User Validator
	/// </summary>
	public class UserValidator : AbstractValidator<User>
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public UserValidator()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.FirstName).Length(0, 50);
			RuleFor(x => x.LastName).Length(0, 50);
			RuleFor(x => x.Username).EmailAddress();
		}
	}
}
