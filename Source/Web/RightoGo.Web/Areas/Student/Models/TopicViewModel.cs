namespace RightoGo.Web.Areas.Student.Models
{
    using RightoGo.Data.Models;
    using RightoGo.Web.Infrastructure.Mapping;

    public class TopicViewModel : IMapFrom<Topic>
    {
        public int Id { get; set; }

        public string Value { get; set; }
    }
}
