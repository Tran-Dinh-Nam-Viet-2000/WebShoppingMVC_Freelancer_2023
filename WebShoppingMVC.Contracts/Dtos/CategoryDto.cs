using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShoppingMVC.Contracts.Dtos.Base;

namespace WebShoppingMVC.Contracts.Dtos
{
    public class CategoryDto : BaseDto
    {
        public string Code { get; set; }
    }
}
