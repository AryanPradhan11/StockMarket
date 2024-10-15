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
        var customer = _context.Customer.ToList();
        return Ok(customer);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id) {
        var customer = _context.Customer.Find(id);
        return Ok(customer);
    }

    [HttpGet("/register")] 
    public IActionResult RedirectUser() {
        return Redirect("http://localhost:5173/register");
    }

    [HttpPost("/login")]
    public IActionResult Login ([FromBody] CustomerModel customerModel) {
        if (customerModel.CustomerFirstName == "Aryan") {
            return Ok(new {redirectUrl = "/login"});
        } else {
            return Unauthorized();
        }
    } 
}