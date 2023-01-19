using Homework5Client.DTO;
using Homework5Client.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using MassTransit;
using System.Drawing;
using Azure;

namespace Homework5Client.Controllers
{
	[Route ("[controller]")]
	public class DirectorController : Controller
	{
		private IUpdateDirectorCommand _updatecommand;
		private IGetDirectorCommand _getcommand;
		private IDeleteDirectorCommand _deletecommand;
		private ICreateDirectorCommand _postcommand;
		public DirectorController(
			IUpdateDirectorCommand updatecommand,
			IGetDirectorCommand getcommand,
			IDeleteDirectorCommand deletecommand,
			ICreateDirectorCommand postcommand)
		{
			_updatecommand = updatecommand;
			_getcommand = getcommand;
			_deletecommand = deletecommand;
			_postcommand = postcommand;

		}

		[HttpPost("post")]
		public async Task<PostDirectorResponse> Create (
			[FromServices] IRequestClient<PostDirectorRequest> request,
			[FromBody] PostDirectorRequest postDirectorRequest)
		{
			var response = await _postcommand.Execute(postDirectorRequest);
			HttpContext.Response.StatusCode = response.StatusCode
				? (int)HttpStatusCode.Created
				: (int)HttpStatusCode.BadRequest;
			return response;
		}

		[HttpGet("get")]
		public async Task<GetDirectorResponse> Get(
			[FromServices] IRequestClient<GetDirectorRequest> request,
			[FromBody] GetDirectorRequest getDirectorRequest)
		{
			var response = await _getcommand.Execute(request, getDirectorRequest);
			HttpContext.Response.StatusCode = response.StatuseCode
				? (int)HttpStatusCode.OK
				: (int)HttpStatusCode.BadRequest;
			return response;
		}
		[HttpDelete("delete")]
		public async Task<DeleteDirectorResponse> Delete(
			[FromServices] IRequestClient<DeleteDirectorRequest> request,
			[FromBody] DeleteDirectorRequest deleteDirectorRequest)
		{
			var response = await _deletecommand.Execute(request, deleteDirectorRequest);
			HttpContext.Response.StatusCode = response.StatuseCode
				? (int)HttpStatusCode.OK
				: (int)HttpStatusCode.BadRequest;
			return response;
		}
		[HttpPut("update")]
		public async Task<UpdateDirectorResponse> Update(
			[FromServices] IRequestClient<UpdateDirectorRequest> request,
			[FromBody] UpdateDirectorRequest updateDirectorRequest)
		{
			var response = await _updatecommand.Execute(request, updateDirectorRequest);
			HttpContext.Response.StatusCode = response.StatuseCode
				? (int)HttpStatusCode.OK
				: (int)HttpStatusCode.BadRequest;
			return response;
		}
	}
}
