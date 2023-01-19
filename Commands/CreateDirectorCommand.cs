using Azure;
using FluentValidation.Results;
using Homework5Client.DTO;
using Homework5Client.Validator;
using MassTransit;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Homework5Client.Commands
{
	public class CreateDirectorCommand : ICreateDirectorCommand
	{
		private readonly ICreateDirectorRequestValidator _validator;
		private readonly IRequestClient<PostDirectorRequest> _requestClient;
		public CreateDirectorCommand(ICreateDirectorRequestValidator validator, IRequestClient<PostDirectorRequest> requestClient)
		{
			_validator = validator;
			_requestClient = requestClient;
		}

		public async Task<PostDirectorResponse> Execute(PostDirectorRequest postDirectorRequest)
		{
			ValidationResult validationResult = _validator.Validate(postDirectorRequest);

			if (!validationResult.IsValid)
			{
				var failresponse = new PostDirectorResponse
				{
					Id = null,
					StatusCode = false,
					Errors = validationResult.Errors.Select(er => er.ErrorMessage).ToList()
				};
				return failresponse;
			}
			var response = (await _requestClient.GetResponse<PostDirectorResponse>(postDirectorRequest)).Message;
			return response;
		}
	}
}
