using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hiba.Services.Contracts;
using System.Threading;

namespace Hiba.ViewComponents
{
    public class ConsultationRequestViewComponent : ViewComponent
    {
        private readonly IConsultationRequest _consultationRequest;
        public ConsultationRequestViewComponent(IConsultationRequest consultationRequest)
        {
            _consultationRequest = consultationRequest;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var _consultationrequest = await _consultationRequest.ConsultationRequest();
            return View(_consultationrequest);
        }
    }
}
