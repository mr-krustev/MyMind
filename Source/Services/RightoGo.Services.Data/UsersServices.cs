namespace RightoGo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using RightoGo.Data.Models;

    public class UsersServices : IUsersServices
    {
        public IQueryable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAllPagedFilteredOrdered(int page, int pageSize, string filterByName, string orderBy, string sortBy)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
