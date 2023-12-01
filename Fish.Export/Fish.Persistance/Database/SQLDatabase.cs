using Fish.Entity.SQL;
using Microsoft.EntityFrameworkCore;

namespace Fish.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Customer> Customer { get; set; }
    }
}