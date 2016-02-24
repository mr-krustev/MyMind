namespace RightoGo.Services.Data.Contracts
{
    using System.Linq;

    using RightoGo.Data.Models;

    public interface IWorksServices
    {
        IQueryable<Work> GetAll();

        IQueryable<Work> GetAllPagedSortedOrdered(int page, int pageSize, string orderBy, string sortBy, string filterByTopic, string searchInput);

        IQueryable<Work> GetById(int id);

        void Update(Work work);

        void Delete(Work work);

        void Add(Work work);

        IQueryable<Work> GetFilteredAndSearched(string filterByTopic, string searchInput);
    }
}
