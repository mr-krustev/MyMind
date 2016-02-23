namespace RightoGo.Web.Areas.Student.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Models;
    using Services.Data.Contracts;
    using ViewModels.Shared;
    using Web.Controllers;

    [Authorize(Roles = "Student, Administrator")]
    public class WorksController : BaseController
    {
        private IWorksServices works;
        private ITopicsServices topics;

        private List<OrderByViewModel> orderByList = new List<OrderByViewModel>()
        {
                new OrderByViewModel() { Value = "asc", Text = "Ascending" },
                new OrderByViewModel() { Value = "desc", Text = "Descending" }
            };

        private List<SortByViewModel> sortByList = new List<SortByViewModel>()
        {
                new SortByViewModel() { Value = "name", Text = "Title" },
                new SortByViewModel() { Value = "date", Text = "Date" }
            };

        public WorksController(IWorksServices works, ITopicsServices topics)
        {
            this.works = works;
            this.topics = topics;
        }

        [HttpGet]
        public ActionResult Index(int page = 1, int pageSize = 5, string orderBy = "desc", string sortBy = "date", string filterByTopic = "", string searchInput = "")
        {
            var data = this.works.GetAllPagedSortedOrdered(page, pageSize, orderBy, sortBy, filterByTopic, searchInput).To<WorkViewModel>().ToList();

            var totalPages = this.works.GetFilteredAndSearched(filterByTopic, searchInput).Count() / pageSize;

            var viewModel = new IndexViewModel()
            {
                Works = data,
                PagingInfo = new PagingViewModel()
                {
                    ActionName = "Index",
                    AreaName = "Student",
                    ControllerName = "Works",
                    Page = page,
                    PageSize = pageSize,
                    OrderBy = orderBy,
                    SortBy = sortBy,
                    OrderByList = this.orderByList,
                    SortByList = this.sortByList,
                    FilterBy = filterByTopic,
                    TotalPages = totalPages
                }
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(404, "Oooooops, something went wrong!");
            }

            var viewModel = this.works.GetById((int)id).To<WorkViewModel>().FirstOrDefault();

            if (viewModel == null)
            {
                throw new HttpException(404, "Oooooops, we could not find what you were looking for!");
            }

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var topics = this.topics.GetAll().To<TopicViewModel>().ToList();

            var viewModel = new AddWorkViewModel()
            {
                Topics = topics
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(AddWorkInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                var topics = this.topics.GetAll().To<TopicViewModel>().ToList();

                var viewModel = new AddWorkViewModel()
                {
                    Title = model.Title,
                    Content = model.Content,
                    Topics = topics
                };
                return this.View(viewModel);
            }

            var topic = this.topics.GetById(model.TopicId).FirstOrDefault();
            var newWork = new Work()
            {
                Title = model.Title,
                Topic = topic,
                Content = model.Content,
                CreatedById = this.User.Identity.GetUserId()
            };

            var workCreated = this.works.Add(newWork).To<WorkViewModel>().FirstOrDefault();

            return this.RedirectToAction("Details", new { id = workCreated.Id });
        }
    }
}
