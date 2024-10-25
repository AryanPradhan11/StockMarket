
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("hospital/userList")]
[ApiController]
public class UserController: ControllerBase {
    private readonly ApplicationDB _context;
    private readonly IUserRepo _userRepo;

    public UserController(ApplicationDB context, IUserRepo userRepo) {
        _context = context;
        _userRepo = userRepo;
    }


    [HttpGet]

    public async Task<IActionResult> GetAll() {
        var listUser = await _userRepo.GetAllUsersAsync();
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
        var customers = await _userRepo.CreateAsyncUser(Customer);
        
        // nameof ensure the correct name of GetByType,
        // userName is the route from GetByType and we are passing the userName to it
        return CreatedAtAction(nameof(GetByType), new {userName = Customer.userName}, customers);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, UpdateUserDto updateUserDto) {
        var updating_user = await _userRepo.UpdateAsyncUser(id, updateUserDto);
        if(updating_user == null) {
            return null;
        }

        return Ok(updating_user.userFilter());
    }

}