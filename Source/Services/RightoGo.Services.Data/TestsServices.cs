namespace RightoGo.Services.Data
{
    using System;
    using System.Linq;

    using Contracts;
    using RightoGo.Data.Common;
    using RightoGo.Data.Models;

    public class TestsServices : ITestsServices
    {
        private IDbRepository<Test> tests;

        public TestsServices(IDbRepository<Test> tests)
        {
            this.tests = tests;
        }

        public void Add(Test test)
        {
            this.tests.Add(test);
            this.tests.Save();
        }

        public void Delete(Test test)
        {
            this.tests.Delete(test);
            this.tests.Save();
        }

        public IQueryable<Test> GetAll()
        {
            return this.tests.All();
        }

        public IQueryable<Test> GetById(int id)
        {
            return this.tests.All().Where(t => t.Id == id);
        }

        public void Update(Test test)
        {
            this.tests.Update(test);
            this.tests.Save();
        }
    }
}
