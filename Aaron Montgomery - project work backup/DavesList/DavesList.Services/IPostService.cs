namespace DavesList.Services
{
    public interface IPostService
    {
        int AddPost(string post, string title);
        
        IQueryable GetPosts(int count);
    }
}
