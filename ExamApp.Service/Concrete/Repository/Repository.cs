using ExamApp.Service.Abstract.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExamApp.Service.Concrete.Repository
{
    public class Repository<TEntity, TContext> : IRepository<TEntity> where TEntity : class where TContext : DbContext, new()
    {
        private TContext _dataContext;
        private readonly DbSet<TEntity> _dbSet;
        protected IDbFactory<TContext> DbFactory
        {
            get;
            private set;
        }
        protected TContext DbContext
        {
            get { return _dataContext ?? (_dataContext = this.DbFactory.Init()); }
        }
        protected Repository(IDbFactory<TContext> dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {

            await _dbSet.AddAsync(entity);
        }
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {

            return await _dbSet.AnyAsync(predicate);
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public IQueryable<TEntity> GetAllAsQueryable()
        {
            return _dbSet;
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public TEntity GetById(long id)
        {
            return _dbSet.Find(id);
        }
        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }
        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }
        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.SingleOrDefaultAsync(predicate);
        }
        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
        public async Task<List<TEntity>> GetAllFilterAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int index = 0, int count = 5)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }


            if (orderBy != null)
            {
                return await orderBy(query).Skip(index).Take(count).ToListAsync();
            }
            else
            {
                return await query.Skip(index).Take(count).ToListAsync();
            }
        }
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }
        public void Add(TEntity entity)
        {
            _dbSet.AddAsync(entity);
        }
        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }
        public IQueryable<TEntity> GetAllAsQueryable(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
        public void UpdateRange(List<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }
    }
}
