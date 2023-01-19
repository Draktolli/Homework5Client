using Homework5Client.DTO;
using MassTransit;
using System.Threading.Tasks;

namespace Homework5Client.Commands
{
	public interface IUpdateDirectorCommand
	{
		public Task<UpdateDirectorResponse> Execute(IRequestClient<UpdateDirectorRequest> request,
			UpdateDirectorRequest updateDirectorRequest);
	}
}
