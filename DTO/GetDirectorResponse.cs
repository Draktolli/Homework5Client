using System;
using System.Collections.Generic;
using Homework5.Entity;

namespace Homework5Client.DTO
{
	public class GetDirectorResponse
	{
		public Guid? Id { get; set; }
		public string? Name { get; set; }
		public string? SurName { get; set; }
		public School? School { get; set; }
		public bool StatuseCode { get; set; }
		public List<string> Errors{ get; set; }
	}
}
