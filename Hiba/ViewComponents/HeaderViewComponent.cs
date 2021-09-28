using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hiba.Services.Contracts;

namespace Hiba.ViewComponents
{
    public class HeaderViewComponent :ViewComponent
    {
        private readonly IHeader _header;

        public HeaderViewComponent(IHeader header)
        {
            _header = header;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Baners = await _header.GetBanners();
            return View(Baners);
        }
    }
}
