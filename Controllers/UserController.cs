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

    [HttpGet("{userType}")]
    public IActionResult GetByType([FromRoute] string userType) {
        var user = _context.Users.Where(x => x.userType == userType).ToList();
        if (user == null) {
            return NotFound();
        }
        return Ok(user);
    }

    
}