namespace RightoGo.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;

    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.Users;

    [Authorize]
    public class UsersController : BaseController
    {
        private IUsersServices users;
        private readonly UserManager<User> manager;

        public UsersController(IUsersServices users, UserManager<User> manager)
        {
            this.users = users;
            this.manager = manager;
        }

        // GET: Users
        public ActionResult ById(string id)
        {
            var user = this.users.GetById(id).To<UserViewModel>().FirstOrDefault();
            var userRoles = this.manager.GetRoles(id);

            user.RoleName = userRoles.FirstOrDefault();

            return this.View(user);
        }
    }
}