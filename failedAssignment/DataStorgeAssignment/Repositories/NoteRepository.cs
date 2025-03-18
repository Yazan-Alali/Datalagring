using DataStorgeAssignment.Contexts;
using DataStorgeAssignment.Entities;

namespace DataStorgeAssignment.Repositories;

public class NoteRepository(DataContext context) : BaseRepository<NoteEntity>(context)
{


}
