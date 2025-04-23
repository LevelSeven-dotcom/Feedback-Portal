using KnowledgeHubPortal.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHubPortal.Web.Controllers
{
    public class CatagoryLinksViewComponent : ViewComponent
    {
        private readonly ICatagoryRepository catagoryRepository;

        public CatagoryLinksViewComponent(ICatagoryRepository catagoryRepository)
        {
            this.catagoryRepository = catagoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var catagories = catagoryRepository.GetAll();
            return View(catagories);
        }
    }
}