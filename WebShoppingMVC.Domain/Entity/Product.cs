using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShoppingMVC.Domain.Entity
{
	public class Product : BaseEntity
	{
		public int Price { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public int CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		public Category Category { get; set; }
	}
}
