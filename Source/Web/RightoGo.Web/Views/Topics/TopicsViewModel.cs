namespace RightoGo.Web.Views.Topics
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class TopicsViewModel : IMapFrom<Topic>
    {
        public int Id { get; set; }

        public string Value { get; set; }
    }
}