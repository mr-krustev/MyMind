namespace RightoGo.Web.Controllers.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Data.Models;
    using Infrastructure.Mapping;
    using Moq;
    using NUnit.Framework;
    using Services.Data.Contracts;
    using TestStack.FluentMVCTesting;
    using ViewModels.Articles;

    [TestFixture]
    public class ArticlesControllerTest
    {
        private List<Article> articleData = new List<Article>() { new Article() { Title = "Test", Topic = new Topic() { Value = "Test" }, Content = "<h1>test</h1>", CreatedBy = new User() { UserName = "Test", Id = "testingid" }, CreatedOn = new DateTime(2000, 10, 10) } };
        private List<Topic> topics = new List<Topic>() { new Topic() { Value = "Test" }, new Topic() { Value = "SecondTest" } };

        [Test]
        public void AllShouldWorkCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(ArticlesController).Assembly);

            var jokesServiceMock = new Mock<IArticlesServices>();
            jokesServiceMock.Setup(x => x.GetAllPagedFilteredSorted(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(this.articleData.AsQueryable());

            var topicsServiceMock = new Mock<ITopicsServices>();
            topicsServiceMock.Setup(x => x.GetAll())
                .Returns(this.topics.AsQueryable());

            var controller = new ArticlesController(jokesServiceMock.Object, topicsServiceMock.Object);
            controller.WithCallTo(x => x.All(1, 5, string.Empty, "desc", "date", string.Empty))
                .ShouldRenderView("All")
                .WithModel<AllArticlesViewModel>(
                    viewModel =>
                        {
                            Assert.AreEqual(this.articleData.First().Content, viewModel.Articles.First().Content);
                            Assert.AreEqual(this.articleData.First().Title, viewModel.Articles.First().Title);
                            Assert.AreEqual(this.articleData.First().Topic.Value, viewModel.Articles.First().Topic.Value);
                            Assert.AreEqual(this.articleData.First().CreatedBy.UserName, viewModel.Articles.First().CreatedBy.UserName);
                            Assert.AreEqual(this.articleData.First().CreatedOn, viewModel.Articles.First().CreatedOn);
                            Assert.AreEqual(1, viewModel.PagingInfo.Page);
                            Assert.AreEqual(5, viewModel.PagingInfo.PageSize);
                            Assert.AreEqual(string.Empty, viewModel.PagingInfo.FilterBy);
                            Assert.AreEqual("desc", viewModel.PagingInfo.OrderBy);
                            Assert.AreEqual("date", viewModel.PagingInfo.SortBy);
                            Assert.AreEqual(string.Empty, viewModel.PagingInfo.SearchInput);
                        }).AndNoModelErrors();
        }
    }
}
