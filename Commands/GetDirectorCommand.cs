using System.Linq;
using Homework5Client.DTO;
using Homework5Client.Validator;
using MassTransit;
using System.Threading.Tasks;
using FluentValidation.Results;
using FluentValidation;
using System.Collections.Generic;

namespace Homework5Client.Commands
{
	public class GetDirectorCommand : IGetDirectorCommand
	{
		private readonly IGetDirectorRequestValidator _validator;

		public GetDirectorCommand(IGetDirectorRequestValidator validator)
		{
			_validator = validator;
		}
		public async Task<GetDirectorResponse> Execute(IRequestClient<GetDirectorRequest> request, GetDirectorRequest getDirectorRequest)
		{
			if (getDirectorRequest is null)
			{
				var msg = "Empty request";
				var failresponse = new GetDirectorResponse
				{
					StatuseCode = false,
					Errors = new List<string>()
				};
				failresponse.Errors.Add(msg);
				return failresponse;
			}

			ValidationResult validationResult = _validator.Validate(getDirectorRequest);

			if (!validationResult.IsValid)
			{
				var failresponse = new GetDirectorResponse
				{
					StatuseCode = false,
					Errors = validationResult.Errors.Select(er => er.ErrorMessage).ToList()
				};
				return failresponse;
			}

			var response = await request.GetResponse<GetDirectorResponse>(getDirectorRequest);

			return response.Message;
		}
	}
}
