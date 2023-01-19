using Homework5Client.DTO;
using MassTransit;
using System.Threading.Tasks;

namespace Homework5Client.Commands
{
	public interface IGetDirectorCommand
	{
		public Task<GetDirectorResponse> Execute(
			IRequestClient<GetDirectorRequest> request,
			GetDirectorRequest getDirectorRequest);
	}
}
