using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Navi2.Data;

namespace Navi2.Pages.myAuditTable
{
    public class CreateModel : PageModel
    {
        private readonly Navi2.Data.ApplicationDbContext _context;

        public CreateModel(Navi2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AuditTable AuditTable { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AuditTable.Add(AuditTable);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}