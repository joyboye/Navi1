using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Navi2.Data
{
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EID { get; set; }
     
        public string FName { get; set; }
        public string LName{ get; set; }
        public DateTime Date { get; set; }
        public int Approved { get; set; }


        [Display (Name = " DeptID")]
        public int DID { get; set; }
        [ForeignKey ("DID")]
        public Dept Department { get; set; }

        [Display(Name = " UserID")]
        public int UserRID { get; set; }
        [ForeignKey("UserRID")]
        public UserRole Users { get; set; }

    }
}
