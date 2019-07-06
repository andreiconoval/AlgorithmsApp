using AlgorithmsApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AlgorithmsApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Algorithm> Algorithms { get; set; }
        public DbSet<AlgorithmStatistic> AlgorithmStatistics { get; set; }
        public DbSet<MockData> MockDatas { get; set; }

    }
}