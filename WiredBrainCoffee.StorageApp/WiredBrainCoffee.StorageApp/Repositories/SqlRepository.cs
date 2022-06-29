using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public delegate void ItemAdded(object item);

    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _dbContext;
        private readonly ItemAdded? _itemAddedCallBack;
        private readonly DbSet<T> _dbSet;
        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item => item.Id).ToList();
        }
        public SqlRepository(DbContext dbContext, ItemAdded? itemAddedCallBack = null)
        {
            _dbContext = dbContext;
            _itemAddedCallBack = itemAddedCallBack;
            _dbSet = _dbContext.Set<T>();
        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
            _itemAddedCallBack?.Invoke(item);

        }
        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
