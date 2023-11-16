using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CansInnov.Application.Contracts.Persistence;
using CansInnov.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CansInnov.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T>
    where T : EntityWithId
    {
        protected readonly CansEventsDbContext _dbcontext;

        public BaseRepository(CansEventsDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbcontext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public virtual async Task<T?> GetByIdWithTrackingAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbcontext.Set<T>().FindAsync(id, cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken)
        {
            return await _dbcontext.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAsync(Func<T, bool> predicate, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _dbcontext.Set<T>().AsNoTracking().Where(predicate).ToList(), cancellationToken);
        }

        public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size, CancellationToken cancellationToken)
        {
            return await _dbcontext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbcontext.Set<T>().AddAsync(entity, cancellationToken);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _dbcontext.Entry(entity).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _dbcontext.Set<T>().Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);
        }
    }
}