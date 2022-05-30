using System.ComponentModel.DataAnnotations;

namespace SNEAKER_SHOP.Models
{
    public class Branch
    {
        [Key]
        public int BranchID { get; set; }
        public string BranchName { get; set; }
    }
}
