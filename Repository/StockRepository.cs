using Microsoft.EntityFrameworkCore;

public class StockRepository: IStockRepo {

    private readonly ApplicationDB _context;
    public StockRepository(ApplicationDB context)
    {
        _context = context;
    }
    public Task<List<User>> GetAllAsync() {
        return _context.Users.ToListAsync();
    }

    public Task<List<Stock>> GetStocksAsync() {
        return _context.Stocks.ToListAsync();
    }

    public async Task<Stock?> CreateStockAsync(Stock stockmodel) {
        await _context.Stocks.AddAsync(stockmodel); // Add only tracks the data 
        await _context.SaveChangesAsync();
        return stockmodel;
    }

    public async Task<Stock?> UpdateStockAsync(int id, UpdateStockDto updateStockDto) {
    var existing = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id); // Ensure using FirstOrDefaultAsync

    if(existing == null) {
        return null; // Correctly returning null for non-existing stock
    }

    // Updating the properties of existing Stock
    existing.Symbol = updateStockDto.Symbol;
    existing.CompanyName = updateStockDto.CompanyName;
    existing.Purchase = updateStockDto.Purchase;
    existing.Industry = updateStockDto.Industry;
    existing.MarketCap = updateStockDto.MarketCap;

    await _context.SaveChangesAsync(); // Save changes asynchronously

    return existing; // Returning the updated Stock
    }


    public async Task<Stock?> DeleteStockAsync(int id) {
        var deleteStock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
        if(deleteStock == null) {
            return null;
        }

        _context.Stocks.Remove(deleteStock);
        await _context.SaveChangesAsync();
        return deleteStock;
    }
}

// repos are to pre-heat the oven before bringing in the database