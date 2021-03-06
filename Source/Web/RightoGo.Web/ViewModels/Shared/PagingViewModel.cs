﻿namespace RightoGo.Web.ViewModels.Shared
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class PagingViewModel
    {
        public int Page { get; set; }

        public int TotalPages { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string AreaName { get; set; }

        public int PageSize { get; set; }

        public string FilterBy { get; set; }

        public string OrderBy { get; set; }

        public IEnumerable<OrderByViewModel> OrderByList { get; set; }

        public string SortBy { get; set; }

        public IEnumerable<SortByViewModel> SortByList { get; set; }

        public string SearchInput { get; set; }

        public IEnumerable<PagingTopicViewModel> Topics { get; set; }
    }
}
