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
    public class AboutTheCenterService: IAboutTheCenter
    {
        private readonly ApplicationDbContext _context;

        public AboutTheCenterService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Page> AboutTheCenter()
        {
            CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

            var page = await _context.Pages?.Where(p => p.Name == "AboutCenter" && p.Lang == cultureInfo.ToString()).FirstOrDefaultAsync();

            return page;
        }
    }
}
