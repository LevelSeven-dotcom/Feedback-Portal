using KnowledgeHubPortal.Domain.Entities;

namespace KnowledgeHubPortal.Domain.Repositories
{
    public interface IArticleRepository
    {
        void SubmitArticle(Article article);
        void ApproveArticles(List<int> articleIds);
        void RejectArticles(List<int> articleIds);

        List<Article> GetArticlesForReview(int catagoryId = 0);
        List<Article> GetArticlesForBrowse(int catagoryId = 0);
    }
}