namespace RightoGo.Data.Common.UserRepoModel
{
    using System.Linq;

    public interface IRepository<T> : IRepository<T, int>
        where T : class
    {
    }

    public interface IRepository<T, in TKey>
        where T : class
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(TKey id);

        void Add(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        void SaveChanges();
    }
}
