namespace DavesList.Services
{
    public interface IPostService
    {
        int AddPost(string post, string title);
        
        IQueryable<Entities.PostItem> GetPosts(int count);
    }
}
