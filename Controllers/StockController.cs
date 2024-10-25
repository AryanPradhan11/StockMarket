using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

[Route("api/stocks")]
[ApiController]
public class StockController: ControllerBase {
    private readonly ApplicationDB _context;
    private readonly IStockRepo _stockRepo;
    public StockController(ApplicationDB context, IStockRepo stockRepo)
    {
        _context = context;
        _stockRepo = stockRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var stocks = await _stockRepo.GetStocksAsync();
        var awaitingStock = stocks.Select(s => s.ToStockDto());
        return Ok(stocks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByAll([FromRoute] int id) {
        var stocks = await _context.Stocks.FindAsync(id);

        if(stocks == null) {
            return NotFound();
        }

        return Ok(stocks.ToStockDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStockDto stockDto) {
        var stockmodel = stockDto.ToStockFromCreateDto();
        await _stockRepo.CreateStockAsync(stockmodel);

        return CreatedAtAction(nameof(GetByAll), new {id = stockmodel.Id}, stockmodel.ToStockDto());
    }

    
    [HttpPut]
    [Route("{id}")]

    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockDto updatestocks) {
        var stockUpdate = await _stockRepo.UpdateStockAsync(id, updatestocks);
        if(stockUpdate == null) {
            return NotFound();
        }
        return Ok(stockUpdate.ToStockDto());
    }

    [HttpDelete]
    [Route("{id}")]

    public async Task<IActionResult> Delete ([FromRoute] int id) {
        var delete = await _stockRepo.DeleteStockAsync(id);
        if(delete == null) {
            return NotFound();
        }

        return NoContent();
    }
}