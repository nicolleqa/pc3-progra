namespace pc3_progra.Services;

using pc3_progra.Models;

public interface INewsService
{
    Task<List<Post>> GetPostsAsync();
    Task<Post> GetPostByIdAsync(int id);
    Task<User> GetUserByIdAsync(int id);
    Task<List<Comment>> GetCommentsByPostIdAsync(int postId);
}