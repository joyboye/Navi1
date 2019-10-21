using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Navi2.Data;

namespace Navi2.Pages.myAuditTable
{
    public class DeleteModel : PageModel
    {
        private readonly Navi2.Data.ApplicationDbContext _context;

        public DeleteModel(Navi2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AuditTable AuditTable { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AuditTable = await _context.AuditTable.FirstOrDefaultAsync(m => m.AuditID == id);

            if (AuditTable == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AuditTable = await _context.AuditTable.FindAsync(id);

            if (AuditTable != null)
            {
                _context.AuditTable.Remove(AuditTable);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
