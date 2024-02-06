using Microsoft.EntityFrameworkCore.ChangeTracking;
using DavesList.Entities;

namespace DavesList.Repositories
{
    public class Repository : IRepository
    {
        public IQueryable<PostItem> PostItems =>
            _davesListContext.PostItems;

        private readonly DavesListContext _davesListContext;
        private bool _disposedValue;

        public Repository(DavesListContext davesListContext)
        {
            _davesListContext = davesListContext;
        }
        
        public EntityEntry<PostItem> AddPost(string post, string title) =>
            _davesListContext.PostItems.Add(new PostItem()
            {
                DateCreated = DateTime.UtcNow,
                Post = post,
                Title = title
            });
        
        public int Save() =>
            _davesListContext.SaveChanges();

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _davesListContext?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }
        
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
