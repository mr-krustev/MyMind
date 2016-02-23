namespace RightoGo.Services.Data.Contracts
{
    using System.Linq;

    using RightoGo.Data.Models;

    public interface IArticlesServices
    {
        void Update(Article article);

        void Delete(Article article);

        IQueryable<Article> GetAll();

        IQueryable<Article> GetAllPagedFilteredSorted(int page, int pageSize, string filterByTopic, string orderBy, string sortBy, string searchInput);

        IQueryable<Article> GetPaged(int page, int size);

        IQueryable<Article> GetFiltered(string filterByTopic);

        IQueryable<Article> GetFilteredAndSearched(string filterByTopic, string searchInput);

        IQueryable<Article> GetById(int id);
    }
}
