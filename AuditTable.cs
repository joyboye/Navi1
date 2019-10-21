using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Navi2.Data
{
    public class AuditTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuditID { get; set; }
        public int UserID { get; set; }
        public int SequenceNumber { get; set; }
        public int Period { get; set; }

        public string Role { get; set; }
        public string ActionTaken { get; set; }
        public DateTime DateStamp { get; set; }


    }
}
