using Data.Contexts;

namespace Data.Repositories;

public class StatusRepository(DataContext context)
{
    private readonly DataContext _context = context;
}
