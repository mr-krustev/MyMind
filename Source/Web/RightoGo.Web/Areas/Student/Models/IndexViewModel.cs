namespace RightoGo.Web.Areas.Student.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using ViewModels.Shared;

    public class IndexViewModel
    {
        public IEnumerable<WorkViewModel> Works { get; set; }

        public PagingViewModel PagingInfo { get; set; }
    }
}