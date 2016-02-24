namespace RightoGo.Services.Data.Contracts
{
    using System.Linq;

    using RightoGo.Data.Models;

    public interface ITestsServices
    {
        IQueryable<Test> GetAll();

        IQueryable<Test> GetById(int id);

        void Add(Test test);

        void Update(Test test);

        void Delete(Test test);
    }
}
