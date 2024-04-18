using Microsoft.EntityFrameworkCore;
using UserManagement.Application.Abstractions.Infrastructure;
using UserManagement.Domain.Dtos.UserManagement;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Contexts;

namespace UserManagement.Infrastructure.Repositories;
internal class UserManagementRepository : BaseRepository, IUserManagementRepository
{
    public UserManagementRepository(UserManagementDbContext context) : base(context)
    { }

    public async Task AddUserAsync(UserEntity user)
    {
        await _context.AppUsers.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CheckIfUserExistAsync(int UserId)
        => await _context.AppUsers.AnyAsync(x => x.Id == UserId &&
        x.Deleted == false);

    public async Task<UserEntity?> GetUserByIdAsync(int UserId)
        => await _context.AppUsers.FirstOrDefaultAsync(x => x.Id == UserId);

    public async Task<IEnumerable<GetUsersResponseDto>> GetUsersAsync()
        => await _context.AppUsers
        .Where(x => x.Deleted == false)
        .Select(x => new GetUsersResponseDto(x.Id,
            x.FirstName,
            x.LastName,
            x.Email,
            x.MobileNumber,
            x.DateOfBirth))
        .ToListAsync();

    public async Task UpdateUserAsync(UserEntity user)
    {
        _context.AppUsers.Update(user);
        await _context.SaveChangesAsync();
    }
}
