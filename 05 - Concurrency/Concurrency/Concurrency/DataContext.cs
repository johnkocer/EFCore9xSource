using Microsoft.EntityFrameworkCore;

namespace Concurrency
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Employee> Employee { get; set; }
  }
}