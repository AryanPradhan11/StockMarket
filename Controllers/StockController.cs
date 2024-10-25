using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

[Route("api/stocks")]
[ApiController]
public class StockController: ControllerBase {
    private readonly ApplicationDB _context;
    public StockController(ApplicationDB context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll() {
        var stocks = _context.Stocks.ToList().Select(s => s.ToStockDto());
        return Ok(stocks);
    }

    [HttpGet("{id}")]
    public IActionResult GetByAll([FromRoute] int id) {
        var stocks = _context.Stocks.Find(id);

        if(stocks == null) {
            return NotFound();
        }

        return Ok(stocks.ToStockDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateStockDto stockDto) {
        var stockmodel = stockDto.ToStockFromCreateDto();
        _context.Stocks.Add(stockmodel); // Add only tracks the data 
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetByAll), new {id = stockmodel.Id}, stockmodel.ToStockDto());
    }

    
    [HttpPut]
    [Route("{id}")]

    public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockDto updatestocks) {
        var stockUpdate = _context.Stocks.FirstOrDefault(x => x.Id == id);

        if(stockUpdate == null) {
            return NotFound();
        }

        stockUpdate.Purchase = updatestocks.Purchase;
        stockUpdate.CompanyName = updatestocks.CompanyName;
        stockUpdate.MarketCap = updatestocks.MarketCap;
        stockUpdate.Divident = updatestocks.Divident;
        stockUpdate.Industry = updatestocks.Industry;
        stockUpdate.Symbol = updatestocks.Symbol;

        _context.SaveChanges();
        return Ok(stockUpdate.ToStockDto());
    }

    [HttpDelete]
    [Route("{id}")]

    public IActionResult Delete ([FromRoute] int id) {
        var delete = _context.Stocks.FirstOrDefault(x => x.Id == id);
        if(delete == null) {
            return NotFound();
        }

        _context.Stocks.Remove(delete);
        _context.SaveChanges();
        return NoContent();
    }
}