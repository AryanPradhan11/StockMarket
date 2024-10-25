using Microsoft.AspNetCore.Mvc;

[Route("api/comment")]
[ApiController]
public class CommentController : ControllerBase {
    private readonly ApplicationDB _context;
    private readonly ICommentRepo _commentRepo;

    public CommentController(ApplicationDB context, ICommentRepo commentRepo)
    {
        _context = context;
        _commentRepo = commentRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllComment() {
        var comment = await _commentRepo.GetAllAsync();
        var commentdto = comment.Select(s => s.commentDto());
        return Ok(commentdto);
    }
}