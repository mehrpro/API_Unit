using API_Unit.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Unit
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<TagRegistered> TagRegistereds { get; set; }
        public virtual DbSet<ReporterStation> ReporterStations { get; set; }
        

    }
}