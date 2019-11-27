using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StaffDatabase.Model;

namespace StaffDatabase.Pages.Staff
{
    public class DeleteModel : PageModel
    {
        private readonly StaffDatabase.Model.StaffDatabaseContext _context;

        public DeleteModel(StaffDatabase.Model.StaffDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StaffMember StaffMember { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StaffMember = await _context.StaffMember.FirstOrDefaultAsync(m => m.IrdNo == id);

            if (StaffMember == null)
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

            StaffMember = await _context.StaffMember.FindAsync(id);

            if (StaffMember != null)
            {
                _context.StaffMember.Remove(StaffMember);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
