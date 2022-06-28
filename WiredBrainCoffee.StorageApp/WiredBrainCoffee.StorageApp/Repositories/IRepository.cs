using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public interface IWriteRepository<in T>//contravarient: if T is used for input only-more specific
    {
        void Add(T item);
        void Remove(T item);
        void Save();
    }

    public interface IReadRepository<out T>//covariant, used for return values and readonly's
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }

    public interface IRepository<T> : IReadRepository <T>, IWriteRepository<T> 
        where T : IEntity
    {
        
    }
}