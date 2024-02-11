using Microsoft.EntityFrameworkCore;
using DavesList.Repositories;

namespace DavesList.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository _repository;
        
        public PostService(IRepository repository)
        {
            _repository = repository;
        }

        public int AddPost(string post, string title)
        {
            _repository.AddPost(post, title);
            return _repository.Save();
        }
        
        public IQueryable<Entities.PostItem> GetPosts(int count) =>
            _repository.PostItems.OrderByDescending(x => x.DateCreated).Take(count).AsNoTracking();
    }
}
