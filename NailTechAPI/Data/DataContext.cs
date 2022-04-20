using Microsoft.EntityFrameworkCore;

namespace NailTechAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<NailTech> NailTechs { get; set; }
    }
}
