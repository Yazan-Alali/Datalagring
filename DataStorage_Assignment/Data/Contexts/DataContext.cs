using Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<CustomerEntity> Customers { get; set; }

    public DbSet<ProductEntity> Products { get; set; }

    public DbSet<StatustypeEntity> Statustypes { get; set; }   

    public DbSet<UserEntity> Users { get; set; }
    
}
