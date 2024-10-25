public interface IStockRepo {
    Task<List<User>> GetAllAsync();
}