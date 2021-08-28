using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hiba.Services.Contracts;

namespace Hiba.ViewComponents
{
    public class NewsViewComponent: ViewComponent
    {
        private readonly INews _Inews;
        public NewsViewComponent(INews Inews)
        {
            _Inews = Inews;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var news = await _Inews.GetNews();
            ViewBag.NewsCount = news.Count;
            return View(news);
        }
    }
}
