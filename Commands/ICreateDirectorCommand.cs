using Homework5Client.DTO;
using MassTransit;
using System.Threading.Tasks;

namespace Homework5Client.Commands
{
	public interface ICreateDirectorCommand
	{
		public Task<PostDirectorResponse> Execute(PostDirectorRequest postDirectorRequest);
	}
}
