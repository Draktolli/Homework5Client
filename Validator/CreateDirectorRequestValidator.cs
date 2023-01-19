using FluentValidation;
using Homework5Client.DTO;

namespace Homework5Client.Validator
{
	public class CreateDirectorRequestValidator : AbstractValidator<PostDirectorRequest>, ICreateDirectorRequestValidator
	{
		public CreateDirectorRequestValidator()
		{
			RuleFor(request => request.Name)
				.Cascade(CascadeMode.Stop)
				.NotEmpty()
				.WithMessage("Name is empty")
				.MaximumLength(15)
				.WithMessage("too long name")
				.MinimumLength(2)
				.WithMessage("too short name");
			RuleFor(request => request.SurName)
				.Cascade(CascadeMode.Stop)
				.NotEmpty()
				.WithMessage("Surname is Empty")
				.MaximumLength(15)
				.WithMessage("too long surname")
				.MinimumLength(5)
				.WithMessage("too short surname");
		}
	}
}
