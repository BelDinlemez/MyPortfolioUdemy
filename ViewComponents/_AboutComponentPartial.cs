using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents
{
    public class _AboutComponentPartial:ViewComponent
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {

            ViewBag.aboutTitle = context.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.aboutSubDescription= context.Abouts.Select(x=>x.SubDescription).FirstOrDefault();
            ViewBag.aboutDetail=context.Abouts.Select(x=>x.Details).FirstOrDefault();
            return View();
        }
    }
}
