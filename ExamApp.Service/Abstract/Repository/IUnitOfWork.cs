using Microsoft.EntityFrameworkCore;

namespace ExamApp.Service.Abstract.Repository
{
    public interface IDbFactory<TContext> : IDisposable where TContext : DbContext, new()
    {
        TContext Init();
    }

    public interface IUnitofWork<TContext> where TContext : DbContext, new()
    {
        Task<int> CommitAsync();
        int Commit();
        Task DisposeAsync();
        Task<int> CommitBulkAsync();
    }
}
