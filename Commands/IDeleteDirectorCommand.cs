using Homework5Client.DTO;
using MassTransit;
using System.Threading.Tasks;

namespace Homework5Client.Commands
{
	public interface IDeleteDirectorCommand
	{
		public Task<DeleteDirectorResponse> Execute(IRequestClient<DeleteDirectorRequest> request,
			DeleteDirectorRequest deleteDirectorRequest);
	}
}
