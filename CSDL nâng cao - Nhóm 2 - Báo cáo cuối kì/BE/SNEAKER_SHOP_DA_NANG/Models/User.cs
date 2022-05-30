using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace SNEAKER_SHOP_DA_NANG.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String FullName { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
        public String Avatar { get; set; }
        public User()
        {
            DayCreated = DateTime.Now;
        }
        public DateTime? DayCreated { get; set; }
        public int BranchId { get; set; }
    }
}
