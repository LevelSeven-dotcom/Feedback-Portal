using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repositories;

namespace KnowledgeHubPortal.Data
{
    public class ArticleRepository : IArticleRepository
    {
        private KHPortalDbContext _context;
        public ArticleRepository(KHPortalDbContext context)
        {
            this._context = context;
        }

        public void ApproveArticles(List<int> articleIds)
        {
            foreach (int id in articleIds)
            {
                var articleToApprove = _context.Articles.Find(id);
                articleToApprove.IsApproved = true;
            }
            _context.SaveChanges();
        }

        public List<Article> GetArticlesForBrowse(int catagoryId = 0)
        {
            var articlesForBrowse = from article in _context.Articles
                                    where article.IsApproved == true
                                    select article;
            if (catagoryId != 0)
            {
                articlesForBrowse = from article in articlesForBrowse
                                    where article.CatagoryId == catagoryId
                                    select article;
            }
            return articlesForBrowse.ToList();
        }

        public List<Article> GetArticlesForReview(int catagoryId = 0)
        {
            var articlesForReview = from article in _context.Articles
                                    where article.IsApproved == false
                                    select article;
            if (catagoryId != 0)
            {
                articlesForReview = from article in articlesForReview

                                    where article.CatagoryId == catagoryId
                                    select article;
            }
            return articlesForReview.ToList();
        }

        public void RejectArticles(List<int> articleIds)
        {
            foreach (int id in articleIds)
            {
                var articleToReject = _context.Articles.Find(id);
                _context.Articles.Remove(articleToReject);
            }
            _context.SaveChanges();
        }

        public void SubmitArticle(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
        }
    }
}