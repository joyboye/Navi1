using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Navi2.Data;

namespace Navi2.Pages.myEmployee
{
    public class IndexModel : PageModel
    {
        private readonly Navi2.Data.ApplicationDbContext _context;

        public IndexModel(Navi2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Employees> Employees { get;set; }

        public async Task OnGetAsync()
        {
            Employees = await _context.Employees
                .Include(e => e.Department).ToListAsync();
        }
    }
}
