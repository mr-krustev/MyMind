namespace RightoGo.Services.Data.Contracts
{
    using System.Linq;
    using RightoGo.Data.Models;

    public interface IUsersServices
    {
        IQueryable<User> GetAll();

        IQueryable<User> GetAllPagedFilteredOrdered(int page, int pageSize, string filterByName, string orderBy, string sortBy);

        IQueryable<User> GetById(string id);


    }
}
