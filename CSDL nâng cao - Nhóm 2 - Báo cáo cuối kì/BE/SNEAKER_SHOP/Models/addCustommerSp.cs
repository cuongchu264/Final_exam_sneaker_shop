using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SNEAKER_SHOP.Models
{
    public class addCustommerSp
    {
        [Required(ErrorMessage = "Vui lòng nhập tên khách hàng")]
        public string CustomerSPName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Email")]
      
        public String CustomerSPEmail { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Phone")]
        public String CustomerSPPhone { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        public String customerSPDescriptions { get; set; }
     
        public int BranchId { get; set; }
    }
}
