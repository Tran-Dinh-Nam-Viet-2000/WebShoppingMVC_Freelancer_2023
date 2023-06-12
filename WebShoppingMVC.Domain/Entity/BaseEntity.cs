using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShoppingMVC.Domain.Entity
{
	public class BaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Required]
		public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool? IsActive { get; set; }
	}
}
