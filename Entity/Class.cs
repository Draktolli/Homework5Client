using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Homework5.Entity
{
	[Table("Classes")]
	public record Class
	{
		public Guid Id { get; set; }
		public int number { get; set; }
		public string liter { get; set; }
		public School? School { get; set; }
		public Teacher? Teacher { get; set; }
	}
}
