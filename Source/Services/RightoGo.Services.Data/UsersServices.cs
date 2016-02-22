namespace RightoGo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using RightoGo.Data.Common.UserRepoModel;
    using RightoGo.Data.Models;

    public class UsersServices : IUsersServices
    {
        private IRepository<User> users;

        public UsersServices(IRepository<User> users)
        {
            this.users = users;
        }

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
            return this.users.All().Where(u => u.Id == id);
        }
    }
}
