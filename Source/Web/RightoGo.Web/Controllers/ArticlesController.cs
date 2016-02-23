﻿namespace RightoGo.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Articles;
    using ViewModels.Shared;
    using System.Collections.Generic;
    public class ArticlesController : BaseController
    {
        private IArticlesServices articles;

        public ArticlesController(IArticlesServices articles)
        {
            this.articles = articles;
        }

        [HttpGet]
        public ActionResult All(int page = 1, int pageSize = 5, string filterByTopic = "", string orderBy = "desc", string sortBy = "date", string searchInput = "")
        {
            IEnumerable<ArticleViewModel> articleData;
            int totalPages;

            if (this.HttpContext.Cache["All_Articles_" + page + "_" + pageSize + "_" + orderBy + "_" + sortBy] != null
                && filterByTopic == string.Empty
                && searchInput == string.Empty)
            {
                articleData = (IEnumerable<ArticleViewModel>)this.HttpContext.Cache["All_Articles_" + page + "_" + pageSize + "_" + orderBy + "_" + sortBy];
                totalPages = (int)this.HttpContext.Cache["All_Articles_" + page + "_" + pageSize + "_" + orderBy + "_" + sortBy + "_TotalPages"];
            }
            else if (filterByTopic != string.Empty || searchInput != string.Empty)
            {
                articleData = this.articles
                                   .GetAllPagedFilteredSorted(page, pageSize, filterByTopic, orderBy, sortBy, searchInput)
                                   .To<ArticleViewModel>().ToList();
                totalPages = (int)Math.Ceiling(this.articles.GetFilteredAndSearched(filterByTopic, searchInput).Count() / (decimal)pageSize);
            }
            else
            {
                articleData = this.articles
                                    .GetAllPagedFilteredSorted(page, pageSize, filterByTopic, orderBy, sortBy, searchInput)
                                    .To<ArticleViewModel>().ToList();
                totalPages = (int)Math.Ceiling(this.articles.GetFilteredAndSearched(filterByTopic, searchInput).Count() / (decimal)pageSize);
                var expiryTime = new TimeSpan(1, 0, 0);
                this.HttpContext.Cache.Insert("All_Articles_" + page + "_" + pageSize + "_" + orderBy + "_" + sortBy, articleData, null, DateTime.MaxValue, expiryTime);
                this.HttpContext.Cache.Insert("All_Articles_" + page + "_" + pageSize + "_" + orderBy + "_" + sortBy + "_TotalPages", totalPages, null, DateTime.MaxValue, expiryTime);
            }

            var viewModel = new AllArticlesViewModel()
            {
                Articles = articleData,
                PagingInfo = new PagingViewModel()
                {
                    Page = page,
                    PageSize = pageSize,
                    OrderBy = orderBy,
                    FilterBy = filterByTopic,
                    SortBy = sortBy,
                    TotalPages = totalPages,
                    SearchInput = searchInput,
                    AreaName = string.Empty,
                    ActionName = "All"
                }
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(404, "Oooooops, something went wrong!");
            }

            var viewModel = this.articles.GetById((int)id).To<ArticleViewModel>().FirstOrDefault();

            if (viewModel == null)
            {
                throw new HttpException(404, "Oooooops, we could not find what you were looking for!");
            }

            return this.View(viewModel);
        }
    }
}