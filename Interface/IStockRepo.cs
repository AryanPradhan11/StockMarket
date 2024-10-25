public interface IStockRepo {
    Task<List<User>> GetAllAsync();
    Task<List<Stock>> GetStocksAsync();
    Task<Stock?> CreateStockAsync(Stock stockmodel);
    Task<Stock?> UpdateStockAsync(int id, UpdateStockDto updateDto);
    Task<Stock?> DeleteStockAsync(int id);
}