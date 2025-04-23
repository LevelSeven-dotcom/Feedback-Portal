using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

namespace KnowledgeHubPortal.Web.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ICatagoryRepository catagoryRepo;
        private readonly IArticleRepository articleRepo;

        public ArticlesController(ICatagoryRepository catagoryRepo, IArticleRepository articleRepo)
        {
            this.catagoryRepo = catagoryRepo;
            this.articleRepo = articleRepo;
        }
        //public IActionResult Index() 
        //{

        //}

        [HttpGet]
        public IActionResult Submit()
        {
            var catagories = catagoryRepo.GetAll();

            ViewBag.Categories = catagories;
            //ViewData["Categories"] = catagories;
            //TempData["Categories"] = catagories;

            return View(new Article());
        }
        
        [HttpPost]
        public IActionResult Submit(Article article)
        {
            // validate
            if (!ModelState.IsValid)
            {
                var catagories = catagoryRepo.GetAll();

                ViewBag.Categories = catagories;
                return View(article);
            }

            article.IsApproved = false;
            article.DateSubmited = DateTime.Now;
            article.SubmitedBy = User.Identity.Name ?? "Unknown";


            articleRepo.SubmitArticle(article);
            TempData["MSG"] = $"Article {article.Title} submited successfully for admin review";
            return RedirectToAction("Submit");
        }

        // .../articles/review
        //[HttpGet]
        public IActionResult Review(int id = 0)
        {
            // fetch the articles for review
            var articlesForReview = articleRepo.GetArticlesForReview(id);
            var catagories = catagoryRepo.GetAll();

            var selectItems = from catagory in catagories
                              select new SelectListItem
                              {
                                  Text = catagory.Name,
                                  Value = catagory.Id.ToString()
                              };

            ViewBag.Catagories = selectItems;
            // send to view
            return View(articlesForReview);
        }

        [HttpPost]
        public IActionResult Approve(List<int> ids)
        {
            articleRepo.ApproveArticles(ids);
            TempData["MSG"] = $"{ids.Count} Articles approved successfully";
            return RedirectToAction("Review");
        }

        [HttpPost]
        public IActionResult Reject(List<int> ids)
        {
            articleRepo.RejectArticles(ids);
            TempData["MSG"] = $"{ids.Count} Articles rejected successfully";
            return RedirectToAction("Review");
        }

        public IActionResult Browse(int id = 0)
        {
            var catagories = catagoryRepo.GetAll();

            var selectItems = from catagory in catagories
                              select new SelectListItem
                              {
                                  Text = catagory.Name,
                                  Value = catagory.Id.ToString()
                              };

            ViewBag.Catagories = selectItems;

            var articlesForBrowse = articleRepo.GetArticlesForBrowse(id);

            return View(articlesForBrowse);
        }

    }
}