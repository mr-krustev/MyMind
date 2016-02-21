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

        public IQueryable<University> GetAll()
        {
            return this.universities.All();
        }
    }
}
