using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hiba.Services.Contracts;
using System.Globalization;
using System.Threading;

namespace Hiba.ViewComponents
{
    public class NewsViewComponent: ViewComponent
    {
        private readonly INews _Inews;
        CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
        CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
        public NewsViewComponent(INews Inews)
        {
            _Inews = Inews;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.News = "News";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.News = "الأخبار";
            }
            var news = await _Inews.GetNews();
            ViewBag.NewsCount = news.Count;
            return View(news);
        }
    }
}
