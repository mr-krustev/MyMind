namespace RightoGo.Web.ViewModels.Home
{
    using RightoGo.Data.Models;
    using RightoGo.Web.Infrastructure.Mapping;

    public class JokeCategoryViewModel : IMapFrom<JokeCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
