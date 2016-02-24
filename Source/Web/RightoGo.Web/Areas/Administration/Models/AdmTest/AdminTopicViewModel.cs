namespace RightoGo.Web.Areas.Administration.Models.AdmTest
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminTopicViewModel : IMapFrom<Topic>
    {
        public int Id { get; set; }

        public string Value { get; set; }
    }
}
