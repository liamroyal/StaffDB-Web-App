using System;
using System.ComponentModel.DataAnnotations;
namespace StaffDatabase.Model
{
    public class StaffMember
    {

        //Properties of a StaffMember instance
        [Display(Name = "First Name")]
        public String Fname { get; set; }

        [Display(Name = "Middle Initial")]
        public String Mname { get; set; }
        [Display(Name = "Last Name")]
        public String Lname { get; set; }
        [Display(Name = "Home Phone")]
        public int HomePh { get; set; }
        [Display(Name = "Mobile Phone")]
        public int CellPh { get; set; }
        [Display(Name = "Office Extension")]
        public int OffExtension { get; set; }
        //IRD unique value
        [Key] 
        [Display(Name = "IRD No")]
        public int IrdNo { get; set; }
        [Display(Name = "Status")]
        public Boolean Status { get; set; }

        public StaffMember()
        {
        }
    }
}
