using Microsoft.EntityFrameworkCore;

namespace WalletApp.DAL.Base
{
    public class BaseRepository<T, I> where T : class
    {
        private readonly WalletAppEntities _dbContext;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(WalletAppEntities dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task Create(T item)
        {
            await _dbSet.AddAsync(item);
        }

        public async Task Delete(I id)
        {
            var item = await _dbSet.FindAsync(id);
            if (item != null)
                _dbSet.Remove(item);
        }

        public async Task<T?> GetByIdAsync(I id, string[]? filter = null)
        {
            if (filter is null)
                return await _dbSet.FindAsync(id);
            else
            {
                var result = CreateFilter(filter);

                //crutch
                var crutch_arr = new List<T>();

                foreach (var res in result)
                    crutch_arr.AddRange(res);

                return await _dbSet.FindAsync(id);
            }
        }

        public IEnumerable<T> GetAll(string[]? filter = null)
        {
            if (filter is null)
                return _dbSet;
            else
            {
                var result = CreateFilter(filter);
                //crutch
                var crutch_arr = new List<T>();

                foreach (var res in result)
                    crutch_arr.AddRange(res);

                return _dbSet;
            }
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }

        private IEnumerable<IQueryable<T>> CreateFilter(string[] filter)
        {
            foreach (var dto in filter)
                yield return _dbSet.Include(dto);
        }
    }
}
