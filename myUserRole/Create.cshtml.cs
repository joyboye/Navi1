using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Navi2.Data;

namespace Navi2.Pages.myUserRole
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
        ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserID");
            return Page();
        }

        [BindProperty]
        public UserRole UserRole { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserRole.Add(UserRole);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}