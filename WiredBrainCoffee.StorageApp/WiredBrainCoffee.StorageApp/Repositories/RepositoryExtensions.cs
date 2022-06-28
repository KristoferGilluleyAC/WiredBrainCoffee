namespace WiredBrainCoffee.StorageApp.Repositories
{
    public static class RepositoryExtensions
    {
        public static void AddBatch<T>(this IWriteRepository<T> repository, T[] items)
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }
            repository.Save();
        }

        public static void PrintNonsense<T>(this IWriteRepository<T> repository)
        {
            Console.WriteLine("Testing out the extends");
        }
    }
}
