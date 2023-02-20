using BuberBreakfast.Models;
using Microsoft.EntityFrameworkCore;

namespace BuberBreakfast.Data;

public class BreakfastDBContext : DbContext
{
    public BreakfastDBContext(DbContextOptions<BreakfastDBContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseOracle("Data Source=localhost:1521/xe;User Id=system;Password=system;", options => options.UseOracleSQLCompatibility("11"));
    }

    //public DbSet<Breakfast> Breakfast { get; set; }
    public DbSet<SimpleBreakfast> SimpleBreakfast { get; set; }
}