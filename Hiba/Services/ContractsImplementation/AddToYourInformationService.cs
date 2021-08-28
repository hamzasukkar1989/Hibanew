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
    public class AddToYourInformationService : IAddToYourInformation
    {
        private readonly ApplicationDbContext _context;

        public AddToYourInformationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Page> AddToYourInformation()
        {
            CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

            var page = await _context.Pages?.Where(p => p.Name == "AddToYourInformation" && p.Lang == cultureInfo.ToString()).FirstOrDefaultAsync();

            return page;
        }
    }
}
