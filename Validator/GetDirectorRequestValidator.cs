using FluentValidation;
using Homework5Client.DTO;

namespace Homework5Client.Validator
{
	public class GetDirectorRequestValidator : AbstractValidator<GetDirectorRequest>, IGetDirectorRequestValidator
	{
		public GetDirectorRequestValidator()
		{
			RuleFor(request => request.Id)
				.Cascade(CascadeMode.Stop)
				.NotEmpty()
				.WithMessage("Id is Empty");
		}
	}
}
