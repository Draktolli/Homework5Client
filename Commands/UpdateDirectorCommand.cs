using System.Linq;
using Homework5Client.DTO;
using Homework5Client.Validator;
using MassTransit;
using System.Threading.Tasks;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Homework5Client.Commands
{
	public class UpdateDirectorCommand : IUpdateDirectorCommand
	{
		private readonly IUpdateDirectorRequestValidator _validator;
		public UpdateDirectorCommand(IUpdateDirectorRequestValidator validator)
		{
			_validator = validator;
		}
		public async Task<UpdateDirectorResponse> Execute(IRequestClient<UpdateDirectorRequest> request, UpdateDirectorRequest updateDirectorRequest)
		{
			if (updateDirectorRequest is null)
			{
				var msg = "Empty request";
				var failresponse = new UpdateDirectorResponse
				{
					StatuseCode = false,
					Errors = new List<string>()
				};
				failresponse.Errors.Add(msg);
				return failresponse;
			}
			ValidationResult validationResult = _validator.Validate(updateDirectorRequest);

			if (!validationResult.IsValid)
			{
				var failresponse = new UpdateDirectorResponse
				{
					StatuseCode = false,
					Errors = validationResult.Errors.Select(er => er.ErrorMessage).ToList()
				};
				return failresponse;
			}
			var response = await request.GetResponse<UpdateDirectorResponse>(updateDirectorRequest);
			return response.Message;
		}
	}
}
