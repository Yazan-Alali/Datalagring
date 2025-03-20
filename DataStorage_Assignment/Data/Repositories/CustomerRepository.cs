using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class CustomerRepository(DataContext context)
{
    private readonly DataContext _context = context;

    // Creat

    // Read

    // Update

    // Delete
    public async Task<bool> DeeleteAsync(int id)
    {
        var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
        {
            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
