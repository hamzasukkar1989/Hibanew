using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hiba.Services.Contracts;
using System.Threading;
using System.Globalization;

namespace Hiba.ViewComponents
{
    public class ConsultationRequestViewComponent : ViewComponent
    {
        private readonly IConsultationRequest _consultationRequest;
        CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
        CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
        public ConsultationRequestViewComponent(IConsultationRequest consultationRequest)
        {
            _consultationRequest = consultationRequest;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var _consultationrequest = await _consultationRequest.ConsultationRequest();
            ViewBag.ConsultationRequest = "Consultation Request";
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.ConsultationRequest = "طلب استشارة";
                ViewBag.align = "right";
            }          
            return View(_consultationrequest);
        }
    }
}
