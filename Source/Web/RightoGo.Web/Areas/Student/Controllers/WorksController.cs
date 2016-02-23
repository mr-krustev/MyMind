namespace RightoGo.Web.Areas.Student.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Models;
    using Services.Data.Contracts;
    using ViewModels.Shared;
    using Web.Controllers;

    [Authorize(Roles = "Student")]
    public class WorksController : BaseController
    {
        private IWorksServices works;

        public WorksController(IWorksServices works)
        {
            this.works = works;
        }

        [HttpGet]
        public ActionResult Index(int page = 1, int pageSize = 5, string orderBy = "desc", string sortBy = "date", string filterByTopic = "")
        {
            var data = this.works.GetAllPagedSortedOrdered(page, pageSize, orderBy, sortBy, filterByTopic).To<WorkViewModel>().ToList();

            var totalPages = this.works.GetFiltered(filterByTopic).Count() / pageSize;

            var viewModel = new IndexViewModel()
            {
                Works = data,
                PagingInfo = new PagingViewModel()
                {
                    ActionName = "Index",
                    AreaName = "Student",
                    Page = page,
                    PageSize = pageSize,
                    OrderBy = orderBy,
                    SortBy = sortBy,
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
    }
}