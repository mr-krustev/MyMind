namespace RightoGo.Services.Data.Contracts
{
    using System.Linq;

    using RightoGo.Data.Models;

    public interface IWorksServices
    {
        IQueryable<Work> GetAll();

        IQueryable<Work> GetAllPagedSortedOrdered(int page, int pageSize, string orderBy, string sortBy, string filterByTopic);

        IQueryable<Work> GetById(int id);

        void Update(Work work);

        void Delete(Work work);

        IQueryable<Work> Add(Work work);

        IQueryable<Work> GetFiltered(string filterByTopic);
    }
}
