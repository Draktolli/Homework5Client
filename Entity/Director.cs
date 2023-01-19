using System;

namespace Homework5.Entity
{
	public record Director
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string SurName { get; set; }
		public Guid? SchoolId { get; set; }
		public School? School { get; set; }
	}
}
