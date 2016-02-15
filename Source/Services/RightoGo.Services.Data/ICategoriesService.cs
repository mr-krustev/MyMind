namespace RightoGo.Services.Data
{
    using System.Linq;

    using RightoGo.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<JokeCategory> GetAll();

        JokeCategory EnsureCategory(string name);
    }
}
