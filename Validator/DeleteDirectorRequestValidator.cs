using System;
using System.Text.RegularExpressions;
using FluentValidation;
using Homework5Client.DTO;

namespace Homework5Client.Validator
{ 
	public class DeleteDirectorRequestValidator : AbstractValidator<DeleteDirectorRequest>, IDeleteDirectorRequestValidator
	{
		private static Regex guidRegex = new(@"^[{(]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[)}]?$");
		public DeleteDirectorRequestValidator()
		{
			RuleFor(request => request)
				.Cascade(CascadeMode.Stop)
				.NotNull()
				.WithMessage("empty model");
			RuleFor(request => request.Id)
				.Must(x => guidRegex.IsMatch(x.ToString()) && !(x.Equals(Guid.Empty)))
				.WithMessage("Id is Empty");
		}
	}
}
