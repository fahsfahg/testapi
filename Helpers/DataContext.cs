namespace TestApi.Helpers;

using Microsoft.EntityFrameworkCore;
using TestApi.Models;

public class DataContext : SkyfrogdbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // in memory database used for simplicity, change to a real db for production applications
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<TbJobprefix> TbJobprefixs { get; set; }
    public DbSet<TbJobtype> TbJobtypes { get; set; }
}