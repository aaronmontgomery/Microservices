using Microsoft.EntityFrameworkCore.ChangeTracking;
using DavesList.Entities;

namespace DavesList.Repositories
{
    public interface IRepository : IDisposable
    {
        IQueryable<PostItem> PostItems { get; }
        
        EntityEntry<PostItem> AddPost(string post, string title);

        int Save();
    }
}
