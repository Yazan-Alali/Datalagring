using DataStorgeAssignment.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataStorgeAssignment.Contexts;

public class DataContext (DbContextOptions<DataContext> options) : DbContext(options)
{

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    public virtual DbSet<NoteEntity> Notes { get; set; }

    public virtual DbSet<ProjectEntity> Projects { get; set; }
}
