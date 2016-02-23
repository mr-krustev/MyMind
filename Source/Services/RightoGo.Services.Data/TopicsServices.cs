namespace RightoGo.Services.Data
{
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

        public void Add(Topic topic)
        {
            this.topics.Add(topic);
            this.topics.Save();
        }

        public void Delete(Topic topic)
        {
            this.topics.Delete(topic);
            this.topics.Save();
        }

        public IQueryable<Topic> GetAll()
        {
            return this.topics.All();
        }

        public IQueryable<Topic> GetById(int id)
        {
            return this.topics.All().Where(t => t.Id == id);
        }

        public void Update(Topic topic)
        {
            this.topics.Update(topic);
            this.topics.Save();
        }
    }
}
