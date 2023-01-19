using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Homework5Client.DTO;
using Homework5Client.Validator;
using MassTransit;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.FileProviders;
using Microsoft.VisualBasic;

namespace Homework5Client.Commands
{
	public class DeleteDirectorCommand : IDeleteDirectorCommand
	{
		private readonly IDeleteDirectorRequestValidator _validator;

		public DeleteDirectorCommand(IDeleteDirectorRequestValidator validator)
		{
			_validator = validator;
		}
		public async Task<DeleteDirectorResponse> Execute(IRequestClient<DeleteDirectorRequest> request, DeleteDirectorRequest deleteDirectorRequest)
		{
			if (deleteDirectorRequest is null)
			{
				var msg = "Empty request";
				var failresponse = new DeleteDirectorResponse
				{
					StatuseCode = false,
					Errors = new List<string>()
				};
				failresponse.Errors.Add(msg);
				return failresponse;
			}
			ValidationResult validationResult = _validator.Validate(deleteDirectorRequest);

			if (!validationResult.IsValid)
			{
				var failresponse = new DeleteDirectorResponse
				{
					StatuseCode = false,
					Errors = validationResult.Errors.Select(er => er.ErrorMessage).ToList()
				};
				return failresponse;
			}

			var response = await request.GetResponse<DeleteDirectorResponse>(deleteDirectorRequest);

			return response.Message;
		}
	}
}
