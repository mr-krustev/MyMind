namespace RightoGo.Services.Data
{
    using System.Linq;

    using RightoGo.Data.Models;

    public interface IJokesService
    {
        IQueryable<Joke> GetRandomJokes(int count);

        Joke GetById(string id);
    }
}
