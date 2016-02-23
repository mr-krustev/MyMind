namespace RightoGo.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.Students;
    using ViewModels.Account;
    [Authorize]
    public class StudentsController : BaseController
    {
        private readonly UserManager<User> manager;
        private IUsersServices users;

        public StudentsController(IUsersServices users, UserManager<User> manager)
        {
            this.users = users;
            this.manager = manager;
        }

        // GET: Students
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult GetAccess()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult RequestAccess(StudentInputModel model)
        {
            // Add to role
            if (!this.ModelState.IsValid)
            {
                return this.View("GetAccess", model);
            }

            var user = this.users.GetById(this.User.Identity.GetUserId()).FirstOrDefault();
            user.Faculty = model.Faculty;
            user.Specialty = model.Specialty;
            var result = this.manager.AddToRole(this.User.Identity.GetUserId(), "Student");
            if (!result.Succeeded)
            {
                this.TempData["Error"] = string.Join(",", result.Errors);
                return this.View("GetAccess", model);
            }

            this.users.Upate(user);

            // Somehow indicate success? TempData["Success"]
            this.TempData["Success"] = "Succesfully requested access! Please log in again so the changes take effect!";
            return this.Redirect("/Account/Login");
        }
    }
}