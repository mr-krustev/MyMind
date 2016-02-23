namespace RightoGo.Services.Data.Contracts
{
    using System.Linq;

    using RightoGo.Data.Models;

    public interface IUniversitiesServices
    {
        IQueryable<University> GetAll();

        IQueryable<University> GetById(int id);

        void Add(University university);

        void Update(University university);

        void Delete(University university);
    }
}
