using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Navi2.Data;

namespace Navi2.Pages.myUserRole
{
    public class EditModel : PageModel
    {
        private readonly Navi2.Data.ApplicationDbContext _context;

        public EditModel(Navi2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserRole UserRole { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserRole = await _context.UserRole
                .Include(u => u.Users).FirstOrDefaultAsync(m => m.UserRID == id);

            if (UserRole == null)
            {
                return NotFound();
            }
           ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRoleExists(UserRole.UserRID))
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

        private bool UserRoleExists(int id)
        {
            return _context.UserRole.Any(e => e.UserRID == id);
        }
    }
}
