namespace RightoGo.Services.Data.Contracts
{
    using System.Linq;
    using RightoGo.Data.Models;

    public interface ILikesServices
    {
        void Add(Like like);

        void Update(Like like);

        IQueryable<Like> GetById(int id);

        IQueryable<Like> GetAll();
    }
}
