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
    public class HeaderViewComponent :ViewComponent
    {
        private readonly IHeader _header;
        CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
        CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

        public HeaderViewComponent(IHeader header)
        {
            _header = header;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            ViewBag.BookNow = "Book now";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.BookNow = "احجز الآن";
            }
            var Baners = await _header.GetBanners();
            return View(Baners);
        }
    }
}
