using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StaffDatabase.Model;

namespace StaffDatabase.Pages.Staff
{
    public class CreateModel : PageModel
    {
        private readonly StaffDatabase.Model.StaffDatabaseContext _context;

        public CreateModel(StaffDatabase.Model.StaffDatabaseContext context)
        {
            // db instance
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StaffMember StaffMember { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var mname = StaffMember.Mname;

            // get middle inital if incase middle name was entered
            StaffMember.Mname = mname.Substring(0, 1);

            // add entrie to db
            _context.StaffMember.Add(StaffMember);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
