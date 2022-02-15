using Hiba.Data;
using Hiba.Models;
using Hiba.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Hiba.Common.Enums;

namespace Hiba.Services.ContractsImplementation
{
    public class NewsService:INews
    {
        private readonly ApplicationDbContext _context;
        public NewsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<News>> GetNews()
        {
            CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

            var page = await _context.News.Where
                (
                n=>n.Sequence==Sequence.First  && n.Lang == cultureInfo.ToString() ||
                n.Sequence == Sequence.Secound && n.Lang == cultureInfo.ToString() ||
                n.Sequence == Sequence.Third   && n.Lang == cultureInfo.ToString() ||
                n.Sequence == Sequence.Fourth  && n.Lang == cultureInfo.ToString()
                ).ToListAsync();
            return page;
        }
    }
}
