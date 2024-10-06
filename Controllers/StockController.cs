using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
}