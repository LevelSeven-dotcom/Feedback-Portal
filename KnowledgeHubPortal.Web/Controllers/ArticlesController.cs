using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

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

    }
}