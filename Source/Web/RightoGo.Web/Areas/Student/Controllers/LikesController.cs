namespace RightoGo.Web.Areas.Student.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using Web.Controllers;

    [Authorize(Roles = "Student, Administrator")]
    public class LikesController : BaseController
    {
        private ILikesServices likes;

        public LikesController(ILikesServices likes)
        {
            this.likes = likes;
        }

        // GET: Student/Votes
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult VoteWork(int? workId, int? likeType)
        {
            if (likeType == null || workId == null)
            {
                throw new HttpException(400, "Something went wrong with the vote.");
            }

            if (likeType < -1)
            {
                likeType = -1;
            }

            if (likeType > 1)
            {
                likeType = 1;
            }

            var userId = this.User.Identity.GetUserId();
            var like = this.likes.GetAll().Where(x => x.VoterId == userId && x.WorkId == workId).FirstOrDefault();

            if (like == null)
            {
                like = new Like()
                {
                    VoterId = userId,
                    WorkId = workId,
                    Type = (LikeType)likeType
                };
                this.likes.Add(like);
            }
            else
            {
                if ((like.Type == LikeType.Positive && likeType == -1) || (like.Type == LikeType.Negative && likeType == 1))
                {
                    like.Type = LikeType.Neutral;
                }
                else
                {
                    like.Type = (LikeType)likeType;
                }

                this.likes.Update(like);
            }

            var result = this.likes.GetAll().Where(x => x.WorkId == workId).ToList().Sum(x => (int)x.Type);

            return this.Json(new { Count = result });
        }
    }
}
