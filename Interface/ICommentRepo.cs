public interface ICommentRepo {
    Task<List<Comment>> GetAllAsync();
}