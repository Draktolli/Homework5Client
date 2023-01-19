using FluentValidation;
using FluentValidation.Results;
using Homework5Client.DTO;

namespace Homework5Client.Validator
{
	public interface ICreateDirectorRequestValidator : IValidator<PostDirectorRequest>
	{
		
	}
}
