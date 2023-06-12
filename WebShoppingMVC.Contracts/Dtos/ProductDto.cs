using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShoppingMVC.Contracts.Dtos.Base;

namespace WebShoppingMVC.Contracts.Dtos
{
    public class ProductDto : BaseDto
    {
        public int Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public IFormFile File { get; set; }
    }
}
