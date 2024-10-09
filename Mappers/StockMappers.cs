using Microsoft.EntityFrameworkCore.Storage;

public static class StockMappers {
    public static StockDto ToStockDto(this Stock stockModel) {
        return new StockDto {
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            Purchase = stockModel.Purchase,
            Divident = stockModel.Divident,
            Industry = stockModel.Industry,
            MarketCap = stockModel.MarketCap
        };
    }
}