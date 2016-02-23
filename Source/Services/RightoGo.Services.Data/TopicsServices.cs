namespace RightoGo.Services.Data
{
    using System;
    using System.Linq;

    using Contracts;
    using RightoGo.Data.Common;
    using RightoGo.Data.Models;

    public class TopicsServices : ITopicsServices
    {
        private IDbRepository<Topic> topics;

        public TopicsServices(IDbRepository<Topic> topics)
        {
            this.topics = topics;
        }

        public IQueryable<Topic> GetAll()
        {
            return this.topics.All();
        }

        public IQueryable<Topic> GetById(int id)
        {
            return this.topics.All().Where(t => t.Id == id);
        }
    }
}
