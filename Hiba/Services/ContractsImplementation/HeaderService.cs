using Hiba.Data;
using Hiba.Models;
using Hiba.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hiba.Services.ContractsImplementation
{
    public class HeaderService:IHeader
    {
        private readonly ApplicationDbContext _context;
        CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
        CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

        public HeaderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Banner>> GetBanners()
        {
            var data = await _context.Banners.Where(b => (b.First || b.Secound) && b.Lang==cultureInfo.ToString()).ToListAsync();
            return data;
        }
    }
}
