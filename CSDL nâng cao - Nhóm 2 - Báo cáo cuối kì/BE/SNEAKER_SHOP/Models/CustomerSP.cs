using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SNEAKER_SHOP.Models
{
    public class CustomerSP
    {
        [Key]
        public int CustomerSPId { get; set; }
        public String CustomerSPName { get; set; }
        public String CustomerSPEmail { get; set; }
        public String CustomerSPPhone { get; set; }
        public String customerSPDescriptions { get; set; }
        public CustomerSP()
        {
            DayCreated = DateTime.Now;
        }
        public DateTime? DayCreated { get; set; }
        public int BranchId { get; set; }
    }
}
