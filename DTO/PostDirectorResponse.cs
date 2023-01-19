using System;
using System.Collections.Generic;

namespace Homework5Client.DTO
{
	public class PostDirectorResponse
	{
		public Guid? Id { get; set; }
		public bool StatusCode { get; set; }
		public List<string> Errors { get; set; }
	}
}
