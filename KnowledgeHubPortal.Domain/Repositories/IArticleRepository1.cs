using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeHubPortal.Domain.Entities;

namespace KnowledgeHubPortal.Domain.Repositories
{
    public interface IArticleRepository1
    {
        void SubmitArticle (Article article);
        void ApproveArticle(List<int>articleIds);
        void RejectArticle(List<int> articleIds);
        List<Article> GetArticlesForReview(int catagoryId = 0);
        List<Article>GetArticlesForBrowse(int  catagoryId = 0);

    }
}
