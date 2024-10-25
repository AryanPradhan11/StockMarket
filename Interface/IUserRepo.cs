public interface IUserRepo {
    Task<List<User>> GetAllUsersAsync();
    Task<User?> CreateAsyncUser(CreateCustomerDto createCustomerDto);

    Task<User?> UpdateAsyncUser(int id, UpdateUserDto updateUserDto);
}