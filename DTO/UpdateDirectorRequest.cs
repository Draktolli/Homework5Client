using System;

namespace Homework5Client.DTO
{
	public class UpdateDirectorRequest
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string SurName { get; set; }
	}
}
