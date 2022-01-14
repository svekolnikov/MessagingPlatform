using MessagingPlatform.DAL.Context;
using MessagingPlatform.Interfaces.Base.Entities;
using MessagingPlatform.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MessagingPlatform.DAL.Repositories
{
    public class DbRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DataDbContext _dbContext;
        private readonly ILogger<DbRepository<T>> _logger;

        protected DbSet<T> Set { get; }
        protected virtual IQueryable<T>? Entities => Set;

        public DbRepository(DataDbContext dbContext, ILogger<DbRepository<T>> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
            Set = _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var items = await Entities.ToArrayAsync(cancellationToken).ConfigureAwait(false);
            return items;
        }

        public async Task<T?> GetById(int id, CancellationToken cancellationToken = default)
        {
            var item = await Entities
                .SingleOrDefaultAsync(x => 
                    x.Id == id, cancellationToken)
                .ConfigureAwait(false);
            return item;
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Set.AddAsync(entity, cancellationToken).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Repository added entity: {0}", entity);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            _logger.LogInformation("Repository updated entity: {0}", entity);
            return entity;
        }

        public async Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            var entityDb = await GetById(entity.Id, cancellationToken).ConfigureAwait(false);
            if (entityDb is null)
            {
                _logger.LogInformation("Entity {0} not found", entity);
                return false;
            }
            _logger.LogInformation("Repository deleted entity: {0}", entity);
            return true;
        }
    }
}
