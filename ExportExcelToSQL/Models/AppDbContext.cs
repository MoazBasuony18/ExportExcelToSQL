using Microsoft.EntityFrameworkCore;

namespace ExportExcelToSQL.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Airport> Airports { get; set; }
    }
}
