using Microsoft.EntityFrameworkCore;
using MillionWebApi.Domain;

namespace MillionWebApi.Data;

public class DataContext : DbContext
{
    public DbSet<People> Peoples => Set<People>();
    public DataContext(DbContextOptions options) : base(options)
    {
    }
}
