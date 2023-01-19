using System.Collections.Generic;

namespace Homework5Client.DTO
{
	public class DeleteDirectorResponse
	{
		public bool StatuseCode { get; set; }
		public List<string> Errors { get; set; }
	}
}
