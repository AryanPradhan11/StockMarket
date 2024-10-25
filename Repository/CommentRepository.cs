using Microsoft.EntityFrameworkCore;

public class CommentRepository: ICommentRepo {
    private readonly ApplicationDB _context;

    public CommentRepository(ApplicationDB context)
    {   
        _context = context;
    }

    public async Task<List<Comment>> GetAllAsync() {
        return await _context.Comments.ToListAsync(); 
    }
}