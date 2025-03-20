using DataStorgeAssignment.Contexts;
using DataStorgeAssignment.Entities;


namespace DataStorgeAssignment.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context)
{



}
