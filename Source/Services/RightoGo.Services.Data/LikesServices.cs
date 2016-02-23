namespace RightoGo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Contracts;
    using RightoGo.Data.Common;
    using RightoGo.Data.Models;

    public class LikesServices : ILikesServices
    {
        private IDbRepository<Like> likes;

        public LikesServices(IDbRepository<Like> likes)
        {
            this.likes = likes;
        }

        public void Add(Like like)
        {
            this.likes.Add(like);
            this.likes.Save();
        }

        public IQueryable<Like> GetAll()
        {
            return this.likes.All();
        }

        public IQueryable<Like> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Like like)
        {
            this.likes.Update(like);
            this.likes.Save();
        }
    }
}
