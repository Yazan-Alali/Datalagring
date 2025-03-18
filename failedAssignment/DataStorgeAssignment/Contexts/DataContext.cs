using DataStorgeAssignment.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataStorgeAssignment.Contexts;

public class DataContext (DbContextOptions<DataContext> options) : DbContext(options)
{

  

    public virtual DbSet<NoteEntity> Notes { get; set; }
}
