using FluentValidation;
using FluentValidation.Results;
using Homework5Client.DTO;

namespace Homework5Client.Validator
{
	public class UpdateDirectorRequestValidator : AbstractValidator<UpdateDirectorRequest>, IUpdateDirectorRequestValidator
	{
		public UpdateDirectorRequestValidator()
		{
			RuleFor(request => request.Id)
				.Cascade(CascadeMode.Stop)
				.NotEmpty()
				.WithMessage("Id is Empty");
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
