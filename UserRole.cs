using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Navi2.Data
{
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserRID { get; set; } 

        public string UserName { get; set; }
        
        public int Open { get; set; }
        public int Contract { get; set; }
        public int Employee { get; set; }

        [Display(Name = " UserID")]
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User Users { get; set; }

    }
}
