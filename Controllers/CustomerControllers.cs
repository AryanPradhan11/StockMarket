using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
[Route("api/customer")]
[ApiController]
public class CustomerControllers : ControllerBase {
    private readonly ApplicationDB _context;
    public CustomerControllers(ApplicationDB context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll() {
        var listallCustomer = _context.Customer.ToList().Select(s => s.)
    }
}