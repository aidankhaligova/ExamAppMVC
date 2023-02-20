using ExamApp.Service.Abstract.Repository;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Service.Concrete.Repository
{
    public class DbFactory<TContext> : IDisposable, IDbFactory<TContext> where TContext : DbContext, new()
    {
        TContext _dbContext;
        public void Dispose()
        {
            _dbContext?.Dispose();
        }
        public TContext Init()
        {
            return _dbContext ?? (_dbContext = new TContext());
        }
    }

    public class UnitOfWork<TContext> : IUnitofWork<TContext> where TContext : DbContext, new()
    {
        private readonly IDbFactory<TContext> _dbFactory;
        private TContext _dbContext;
        public UnitOfWork(IDbFactory<TContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public TContext DbContext
        {
            get { return _dbContext ?? (_dbContext = _dbFactory.Init()); }
        }

        public int Commit()
        {
            return DbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {

            return await DbContext.SaveChangesAsync();
        }
        public async Task<int> CommitBulkAsync()
        {

            return await DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        public async Task DisposeAsync()
        {
            await DbContext.DisposeAsync();
        }
    }
}
