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
    public class AddToYourInformationViewComponent : ViewComponent
    {
        private readonly IAddToYourInformation _addToYourInformation;
        CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
        CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
        public AddToYourInformationViewComponent(IAddToYourInformation addToYourInformation)
        {
            _addToYourInformation = addToYourInformation;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.Title1 = "Add To Your";
            ViewBag.Title2 = "Information";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.Title1 = "أضف إلى ";
                ViewBag.Title2 = "معلوماتك";
            }
            var addToYourInformation = await _addToYourInformation.AddToYourInformation();
            return View(addToYourInformation);
        }
    }
}
