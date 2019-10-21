using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Navi2.Data;

namespace Navi2.Pages.myAuditTable
{
    public class EditModel : PageModel
    {
        private readonly Navi2.Data.ApplicationDbContext _context;

        public EditModel(Navi2.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AuditTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditTableExists(AuditTable.AuditID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AuditTableExists(int id)
        {
            return _context.AuditTable.Any(e => e.AuditID == id);
        }
    }
}
