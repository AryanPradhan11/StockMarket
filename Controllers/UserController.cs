<<<<<<< HEAD
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("hospital/userList")]
[ApiController]
public class UserController: ControllerBase {
    private readonly ApplicationDB _context;

    public UserController(ApplicationDB context) {
        _context = context;
    }

    [HttpGet]

    public IActionResult GetAll() {
        var listUser = _context.Users.ToList().Select(s => s.userFilter());
        return Ok(listUser);
    }

    // [HttpGet("{userID}")]
    // public IActionResult GetById([FromRoute] int userID) {
    //     var type = _context.Users.Find(userID);
    //     if(type == null) {
    //         return NotFound();
    //     }
    //     return Ok(type.userFilter());
    // }

    [HttpGet("{userName}")]
    //userName is the route
    public async Task<IActionResult> GetByType([FromRoute] string userName) {
        var user = await _context.Users.ToListAsync();

        var awaiting_user = user.Where(x => x.userName == userName);
        if (user == null) {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerDto Customer) {
        var customers = Customer.createCustomer();
        await _context.Users.AddAsync(customers);
        await _context.SaveChangesAsync();
        // nameof ensure the correct name of GetByType,
        // userName is the route from GetByType and we are passing the userName to it
        return CreatedAtAction(nameof(GetByType), new {userName = Customer.userName}, customers);
    }

    [HttpGet]
    [Route("/getall")]
    public async Task<IActionResult> GetByAsync() {
        var users = await _context.Users.ToListAsync();

        var usersDTO = users.Select(s => s.userFilter());

        return Ok (users);
    }
=======
using Microsoft.AspNetCore.Mvc;

[Route("hospital/userList")]
[ApiController]
public class UserController: ControllerBase {
    private readonly ApplicationDB _context;

    public UserController(ApplicationDB context) {
        _context = context;
    }

    [HttpGet]

    public IActionResult GetAll() {
        var listUser = _context.Users.ToList().Select(s => s.userFilter());
        return Ok(listUser);
    }

    // [HttpGet("{userID}")]
    // public IActionResult GetById([FromRoute] int userID) {
    //     var type = _context.Users.Find(userID);
    //     if(type == null) {
    //         return NotFound();
    //     }
    //     return Ok(type.userFilter());
    // }

    [HttpGet("{userName}")]
    //userName is the route
    public IActionResult GetByType([FromRoute] string userName) {
        var user = _context.Users.Where(x => x.userName == userName).ToList();
        if (user == null) {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateCustomerDto Customer) {
        var customers = Customer.createCustomer();
        _context.Users.Add(customers);
        _context.SaveChanges();
        // nameof ensure the correct name of GetByType,
        // userName is the route from GetByType and we are passing the userName to it
        return CreatedAtAction(nameof(GetByType), new {userName = Customer.userName}, customers);
    }
>>>>>>> 90b45dd180fc4644323cc99007f2c0eb93fff75a
}