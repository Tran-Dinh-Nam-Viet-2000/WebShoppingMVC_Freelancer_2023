using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShoppingMVC.Data.Context
{
    public class DbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=TRANDINHNAMVIET\\SQLEXPRESS;Initial Catalog=WebShoppingMVC_Freelancer;Persist Security Info=True;User ID=sa;Password=123;TrustServerCertificate=true");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
