using Homework5.Entity;

namespace Homework5Client.DTO
{
	public class PostDirectorRequest
	{
		public string Name { get; set; }
		public string SurName { get; set; }
		public School? School { get; set; }
	}
}
