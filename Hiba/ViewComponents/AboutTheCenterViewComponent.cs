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
    public class AboutTheCenterViewComponent: ViewComponent
    {
        private readonly IAboutTheCenter _aboutTheCenter;
        CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
        CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
        public AboutTheCenterViewComponent(IAboutTheCenter aboutTheCenter)
        {
            _aboutTheCenter = aboutTheCenter;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.Title1 = "About the ";
            ViewBag.Title2 = "Center";
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.Title1 = "نبذة عن ";
                ViewBag.Title2 = "المركز";
                ViewBag.align = "right";
            }
            var aboutthecenter = await _aboutTheCenter.AboutTheCenter();
            return View(aboutthecenter);
        }
    }
}
