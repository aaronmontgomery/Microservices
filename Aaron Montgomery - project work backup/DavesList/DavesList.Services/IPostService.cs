namespace DavesList.Services
{
    public interface IPostService
    {
        int AddPost(string post, string title);

        IEnumerable<Entities.PostItem> GetPosts(int count);
    }
}
