namespace RightoGo.Services.Data
{
    using System;
    using System.Linq;

    using Contracts;
    using RightoGo.Data.Common;
    using RightoGo.Data.Models;

    public class ArticlesServices : IArticlesServices
    {
        private IDbRepository<Article> articles;

        public ArticlesServices(IDbRepository<Article> articles)
        {
            this.articles = articles;
        }

        public IQueryable<Article> GetOrdered(string orderBy)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Article> GetPaged(int page = 1, int size = 5)
        {
            return this.articles
                .All()
                .OrderByDescending(a => a.CreatedOn)
                .Skip((page - 1) * size)
                .Take(size);
        }
    }
}
