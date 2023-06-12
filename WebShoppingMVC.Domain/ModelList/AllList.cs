using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShoppingMVC.Domain.Entity;

namespace WebShoppingMVC.Domain.ModelList
{
    public class AllList
    {
        public List<Product> ListProduct { get; set; }
        public List<Product> ListProductShirt { get; set; }
    }
}
