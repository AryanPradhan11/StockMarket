using Microsoft.EntityFrameworkCore;

public class UserRepository: IStockRepo {

    private readonly ApplicationDB _context;
    public UserRepository(ApplicationDB context)
    {
        _context = context;
    }
    public Task<List<User>> GetAllAsync() {
        return _context.Users.ToListAsync();
    }
}

// repos are to pre-heat the oven before bringing in the database