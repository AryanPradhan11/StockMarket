using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Configuration.UserSecrets;

public class UserRepository : IUserRepo {
    private readonly ApplicationDB _context;

    public UserRepository(ApplicationDB context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllUsersAsync() {
        var userList = await _context.Users.ToListAsync();
        return userList;
    }

    public async Task<User?> CreateAsyncUser(CreateCustomerDto createCustomerDto) {
        var CreateCustomer = createCustomerDto.createCustomer();
        await _context.Users.AddAsync(CreateCustomer);
        await _context.SaveChangesAsync();

        return CreateCustomer;
    }

    public async Task<User?> UpdateAsyncUser(int id, UpdateUserDto updateUserDto) {
        var updateUser = await _context.Users.FirstOrDefaultAsync(x => x.userID == id);
        if(updateUser == null) {
            return null;
        }

        updateUser.userID = updateUserDto.userId;
        updateUser.userName = updateUserDto.userName;
        updateUser.userType = updateUserDto.userType;

        await _context.SaveChangesAsync();
        return updateUser;
    }
}