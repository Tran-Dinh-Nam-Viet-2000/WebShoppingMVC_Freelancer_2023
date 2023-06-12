using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShoppingMVC.Domain.Entity
{
	public class Category : BaseEntity
	{
        [Required]
        public string? Code { get; set; }
	}
}
