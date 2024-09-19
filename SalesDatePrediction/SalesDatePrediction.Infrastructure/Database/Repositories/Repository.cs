using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Repositories;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace SalesDatePrediction.Infrastructure.Database.Repositories
{
    [ExcludeFromCodeCoverage]
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : ModelBase
    {
        private readonly SalesDatesPredictionContext _context;

        public Repository(SalesDatesPredictionContext context)
        {
            _context = context;
        }

        public async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await _context.Set<TEntity>().FindAsync(keyValues).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
              Expression<Func<TEntity, bool>> filter = null,
              Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
              string includeProperties = "")
        {
            return await CreateQuery(filter, orderBy, includeProperties).ToListAsync().ConfigureAwait(false);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await CreateQuery(filter).CountAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = _context.Set<TEntity>().AsNoTracking();

            return filter is null ? await query.AnyAsync().ConfigureAwait(false) : await query.AnyAsync(filter).ConfigureAwait(false);
        }

        public async Task AddVoidAsync(TEntity entity)
        {
            ValidateEntity(entity);

            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            ValidateEntity(entity);

            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            ValidateEntities(entities);

            _context.Set<TEntity>().AddRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            ValidateEntity(entity);

            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            ValidateEntities(entities);

            _context.Set<TEntity>().UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            ValidateEntity(entity);

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            ValidateEntities(entities);

            _context.Set<TEntity>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(FormattableString query)
        {
            return await _context.Set<TEntity>().FromSqlInterpolated(query).ToListAsync();
        }

        private IQueryable<TEntity> CreateQuery(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            var query = _context.Set<TEntity>().AsNoTracking();

            if (filter is not null)
            {
                query = query.Where(filter);
            }

            includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(p => query = query.Include(p));

            if (orderBy is not null)
            {
                return orderBy(query);
            }

            return query;
        }

        private static void ValidateEntity(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity), "El objeto entidad no puede ser nulo");
            }
        }

        private static void ValidateEntities(IEnumerable<TEntity> entities)
        {
            if (!entities?.Any() ?? true)
            {
                throw new ArgumentNullException(nameof(entities), "no se envió una lista de entidades a insertar");
            }
        }
    }
}
