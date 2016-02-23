namespace RightoGo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using RightoGo.Data.Common;
    using RightoGo.Data.Models;

    public class UniversitiesServices : IUniversitiesServices
    {
        private IDbRepository<University> universities;

        public UniversitiesServices(IDbRepository<University> universities)
        {
            this.universities = universities;
        }

        public void Add(University university)
        {
            this.universities.Add(university);
            this.universities.Save();
        }

        public void Delete(University university)
        {
            this.universities.Delete(university);
            this.universities.Save();
        }

        public IQueryable<University> GetAll()
        {
            return this.universities.All();
        }

        public IQueryable<University> GetById(int id)
        {
            return this.universities.All().Where(u => u.Id == id);
        }

        public void Update(University university)
        {
            this.universities.Update(university);
            this.universities.Save();
        }
    }
}
