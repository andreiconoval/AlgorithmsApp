using AlgorithmsApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AlgorithmsApp.API.Data
{
    public class DataContext : DbContext
    { 
        //private IConfiguration Configuration { get; }
        
        // public DataContext(IConfiguration configuration)
        // {
        //     Configuration = configuration;
        // }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         optionsBuilder.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        //     }

        // }


        public DbSet<Algorithm> Algorithms { get; set; }
        public DbSet<AlgorithmStatistic> AlgorithmStatistics { get; set; }
        public DbSet<MockData> MockDatas { get; set; }

    }
}