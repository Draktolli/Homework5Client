using Homework5.Entity;
using Microsoft.EntityFrameworkCore;

namespace Homework5.DB
{
	public class DBContext : DbContext
	{
		public DbSet<Director> Directors { get; set; } = null!;
		public DbSet<School> Schools { get; set; } = null!;
		public DbSet<Class> Classs { get; set; } = null!;
		public DbSet<Teacher> Teachers { get; set; } = null!;
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<Director>()
				.HasOne(b => b.School)
				.WithOne(i => i.Director)
				.HasForeignKey<School>(b => b.DirectorId);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=ScholDB;Trusted_Connection=True;TrustServerCertificate=true;");
		}
	}
}
