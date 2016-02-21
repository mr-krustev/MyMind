namespace RightoGo.Services.Data.Contracts
{
    using System.Linq;

    using RightoGo.Data.Models;

    public interface IArticlesServices
    {
        IQueryable<Article> GetPaged(int page, int size);

        IQueryable<Article> GetOrdered(string orderBy);
    }
}
