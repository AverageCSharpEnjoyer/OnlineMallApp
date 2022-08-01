using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMall.Data;
using OnlineMall.Models;

namespace OnlineMall.Data
{
	public class BusinessDbContext : DbContext
	{
		public BusinessDbContext(DbContextOptions<BusinessDbContext> options)
			:base(options)
		{
			Console.WriteLine("business db context constructor");
		}

		public DbSet<Invoice> Invoice { get; set; }
	}
}
