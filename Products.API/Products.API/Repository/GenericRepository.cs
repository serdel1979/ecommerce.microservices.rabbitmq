
using Microsoft.EntityFrameworkCore;
using Products.API.Infra;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Products.API.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ProductsContext _context;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(ProductsContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<TEntity>();
        }


        public async Task Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public async Task Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<TEntity> Get(int id, params string[] includes)
        {
            var query = _dbSet.AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }

        //public async Task<IQueryable<TEntity>> GetAll(int Page = 1, int Size = 5)
        //{
        //    return _dbSet.Skip((Page - 1) * Size).Take(Size).AsQueryable();
        //}

        public async Task<(List<TEntity> Data, int TotalRecords)> GetAll(int page, int size, params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var totalRecords = await query.CountAsync();

            var data = await query
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

            return (data, totalRecords);
        }

        public async Task save()
        {
            _context.SaveChanges();
        }

        public async Task Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}
