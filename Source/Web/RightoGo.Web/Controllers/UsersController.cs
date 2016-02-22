namespace RightoGo.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Users;

    [Authorize]
    public class UsersController : BaseController
    {
        private IUsersServices users;

        public UsersController(IUsersServices users)
        {
            this.users = users;
        }

        // GET: Users
        public ActionResult ById(string id)
        {
            var user = this.users.GetById(id).To<UserViewModel>().FirstOrDefault();

            return this.View(user);
        }
    }
}