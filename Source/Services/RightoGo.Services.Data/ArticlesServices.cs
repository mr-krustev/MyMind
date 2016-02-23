namespace RightoGo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;

    using Contracts;
    using RightoGo.Data.Common;
    using RightoGo.Data.Models;

    public class ArticlesServices : IArticlesServices
    {
        private IDbRepository<Article> articles;
        private IDictionary<string, string> sortValues;

        public ArticlesServices(IDbRepository<Article> articles)
        {
            this.articles = articles;
            this.sortValues = new Dictionary<string, string>();
            this.sortValues.Add("date", "CreatedOn");
            this.sortValues.Add("name", "Title");
        }

        public IQueryable<Article> GetAll()
        {
            return this.articles.All();
        }

        public void Update(Article article)
        {
            this.articles.Update(article);
            this.articles.Save();
        }

        public void Delete(Article article)
        {
            this.articles.Delete(article);
            this.articles.Save();
        }

        public IQueryable<Article> GetAllPagedFilteredSorted(int page, int pageSize, string filterByTopic, string orderBy, string sortBy)
        {
            var result = this.articles.All();

            if (filterByTopic != string.Empty && filterByTopic != null && filterByTopic != "")
            {
                result = result.Where(a => a.Topic.Value == filterByTopic);
            }

            var sort = this.sortValues[sortBy];

            // TODO: Fix OrderBy to work.
            return result
                .OrderBy(sort + " " + orderBy)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public IQueryable<Article> GetById(int id)
        {
            return this.articles.All().Where(a => a.Id == id);
        }

        public IQueryable<Article> GetFiltered(string filterByTopic)
        {
            var result = this.articles.All();

            if (filterByTopic != string.Empty && filterByTopic != null && filterByTopic != "")
            {
                result = result.Where(a => a.Topic.Value == filterByTopic);
            }

            return result;
        }

        public IQueryable<Article> GetPaged(int page, int pageSize)
        {
            return this.articles
                .All()
                .OrderByDescending(a => a.CreatedOn)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
