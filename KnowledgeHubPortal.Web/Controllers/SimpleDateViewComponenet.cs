using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHubPortal.Web.Controllers
{
    public class SimpleDateViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.Date = DateTime.Now;
            return View();
        }
    }
}