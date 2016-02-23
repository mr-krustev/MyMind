namespace RightoGo.Services.Data.Contracts
{
    using System.Linq;

    using RightoGo.Data.Models;

    public interface IUniversitiesServices
    {
        IQueryable<University> GetAll();
    }
}
