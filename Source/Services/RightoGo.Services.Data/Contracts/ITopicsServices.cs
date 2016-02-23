namespace RightoGo.Services.Data.Contracts
{
    using System.Linq;

    using RightoGo.Data.Models;

    public interface ITopicsServices
    {
        IQueryable<Topic> GetAll();

        IQueryable<Topic> GetById(int id);

        void Add(Topic topic);

        void Update(Topic topic);

        void Delete(Topic topic);
    }
}
