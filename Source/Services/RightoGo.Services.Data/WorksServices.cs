namespace RightoGo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;

    using Contracts;
    using RightoGo.Data.Common;
    using RightoGo.Data.Models;

    public class WorksServices : IWorksServices
    {
        private IDbRepository<Work> works;
        private IDictionary<string, string> sortValues;

        public WorksServices(IDbRepository<Work> works)
        {
            this.works = works;
            this.sortValues = new Dictionary<string, string>();
            this.sortValues.Add("date", "CreatedOn");
            this.sortValues.Add("name", "Title");
        }

        public void Add(Work work)
        {
            this.works.Add(work);
            this.works.Save();
        }

        public IQueryable<Work> GetAll()
        {
            return this.works.All();
        }

        public IQueryable<Work> GetAllPagedSortedOrdered(int page, int pageSize, string orderBy, string sortBy, string filterByTopic, string searchInput)
        {
            var result = this.works.All();

            if (filterByTopic != string.Empty && filterByTopic != null)
            {
                result = result.Where(a => a.Topic.Value == filterByTopic);
            }

            var sort = this.sortValues[sortBy];

            // TODO: Fix OrderBy to work.
            return result
                .Where(w => w.Title.Contains(searchInput) || w.Content.Contains(searchInput))
                .OrderBy(sort + " " + orderBy)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public void Delete(Work work)
        {
            this.works.Delete(work);
            this.works.Save();
        }

        public IQueryable<Work> GetById(int id)
        {
            return this.works.All().Where(w => w.Id == id);
        }

        public void Update(Work work)
        {
            this.works.Update(work);
            this.works.Save();
        }

        public IQueryable<Work> GetFilteredAndSearched(string filterByTopic, string searchInput)
        {
            var result = this.works.All();

            if (filterByTopic != string.Empty && filterByTopic != null)
            {
                result = result.Where(a => a.Topic.Value == filterByTopic);
            }

            return result
                .Where(w => w.Title.Contains(searchInput) || w.Content.Contains(searchInput));
        }
    }
}
