using UserManagement.Infrastructure.Contexts;

namespace UserManagement.Infrastructure.Repositories;

internal abstract class BaseRepository
{
    protected UserManagementDbContext _context;

    protected BaseRepository(UserManagementDbContext context)
    {
        _context = context;
    }
}
