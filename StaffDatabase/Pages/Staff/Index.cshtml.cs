using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using iTextSharp.text;
using iTextSharp.text.pdf;
using StaffDatabase.Model;
using System.IO;

namespace StaffDatabase.Pages.Staff
{
    public class IndexModel : PageModel
    {
        private readonly StaffDatabase.Model.StaffDatabaseContext _context;
        public int entries;

        public IndexModel(StaffDatabase.Model.StaffDatabaseContext context)
        {
            _context = context;
            this.entries = 0;
        }

        public IList<StaffMember> StaffMember { get;set; }

        public async Task OnGetAsync()
        {
            StaffMember = await _context.StaffMember.ToListAsync();

            //count table entries
            this.entries = 0; //reset entries variable
            //retrieve all rows
            var rows = from tuple in _context.StaffMember
                       select tuple;
            //set entry count
            this.entries = rows.Count();
        }

        public IActionResult OnPostCSV()
        {
            //store data
            var data = from tuple in _context.StaffMember
                       select tuple;

            //create CSV
            var csv = new StringBuilder();

            //append header values
            csv.Append("FirstName, MInitial, LastName, HomePh, CellPh, OffExt, IrdNo, Status");

            //append rows
            foreach (StaffMember i in data)
            {
                //instance data
                csv.AppendLine();
                csv.Append(i.Fname + ", ");
                csv.Append(i.Mname + ", ");
                csv.Append(i.Lname + ", ");
                csv.Append(i.HomePh + ",");
                csv.Append(i.CellPh + ",");
                csv.Append(i.OffExtension + ",");
                csv.Append(i.IrdNo + ",");

                //handle booleans
                if (i.Status) csv.Append("Active");
                else csv.Append("InActive");
            }

            return File(new System.Text.UTF8Encoding().GetBytes(csv.ToString()), "text/txt", "StaffContacts.csv");
        }

        public IActionResult OnPostPrint()
        {
            //create pdf 
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 7f, 5f, 5f, 0f);
            //save to desktop
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("/Users/liam/Desktop/Contacts.pdf", FileMode.Create));
            doc.SetMargins(50, 50, 40, 40);
            doc.Open();

            //retrieve data
            var data = from tuple in _context.StaffMember
                       select tuple;

            //format each instance
            foreach (StaffMember i in data)
            {
                Paragraph temp = new Paragraph(i.Fname + " " + i.Mname.Substring(0, 1) + " " + i.Lname + "\nMobile Ph: "
                    + i.CellPh + "\nHome Ph: " + i.HomePh + "\nOffice Extension: " + i.OffExtension + "\nIRD No: "
                    + i.IrdNo + "\nActive: " + i.Status+"\n\n");

                //Used to split multiple paragrahs
                Paragraph lineBreak = new Paragraph();

                doc.Add(temp);
                doc.Add(lineBreak);
            }

            //close pdf document
            doc.Close();

            //return to home page
            return RedirectToPage();
        }
    }
}
