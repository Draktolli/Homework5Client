using System.Collections.Generic;
using System;

namespace Homework5.Entity
{
	public record School
	{
		public Guid Id { get; set; }
		public int Number { get; set; }
		public Guid DirectorId { get; set; }
		public Director Director { get; set; }
		public List<Class> Classes { get; set; } = new List<Class>();
		public List<Teacher> Teachers { get; set; } = new List<Teacher>();
	}
}
