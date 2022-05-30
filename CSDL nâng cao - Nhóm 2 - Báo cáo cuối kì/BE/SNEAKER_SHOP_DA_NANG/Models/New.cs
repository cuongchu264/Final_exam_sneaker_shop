using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SNEAKER_SHOP_DA_NANG.Models
{
    public class New
    {
		[Key]
		public int NewId { get; set; }
		public string NewTitle { get; set; }
		public string NewComment { get; set; }
		public string NewImg { get; set; }
		public string NewLink { get; set; }
		public int NewCategory { get; set; }
		public string NewCategoryName { get; set; }
		public int BranchID { get; set; }
	}
}
