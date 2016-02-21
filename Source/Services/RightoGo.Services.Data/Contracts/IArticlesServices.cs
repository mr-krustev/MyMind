namespace RightoGo.Services.Data.Contracts
{
    using System.Linq;

    using RightoGo.Data.Models;

    public interface IArticlesServices
    {
        IQueryable<Article> GetAll(int page, int pageSize, string filterByTopic, string orderBy, string sortBy);

        IQueryable<Article> GetPaged(int page, int size);

        IQueryable<Article> GetFiltered(string filterByTopic);

        IQueryable<Article> GetById(int id);
    }
}
