using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.Controllers
{
    public class StatisticController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Index()
        {
            ViewBag.v1 = context.Skills.Count();
            ViewBag.v2 = context.Messages.Count();
            ViewBag.v3 = context.Messages.Where(x => x.IsRead == false).Count();
            ViewBag.v4 = context.Messages.Where(x => x.IsRead == true).Count();

            int doneCount = context.ToDoLists.Count(x => x.Status == true);
            int notDoneCount = context.ToDoLists.Count(x => x.Status == false);

            // Eğer veri hiç yoksa (grafik boş kalmasın diye)
            if (doneCount == 0 && notDoneCount == 0)
            {
                doneCount = 1;
                notDoneCount = 1;
            }

            ViewBag.ToDoDonut = new int[] { doneCount, notDoneCount };

            ViewBag.PortfolioCount = context.Portfolios.Count();
            ViewBag.ExperienceCount = context.Experiences.Count();
            return View();

        }
    }
}
