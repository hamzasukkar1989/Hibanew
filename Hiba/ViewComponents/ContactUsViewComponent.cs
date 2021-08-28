using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hiba.Services.Contracts;

namespace Hiba.ViewComponents
{
    public class ContactUsViewComponent: ViewComponent
    {
        //public ContactUsViewComponent()
        //{

        //}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.Run(() => View());
        }
    }
}
