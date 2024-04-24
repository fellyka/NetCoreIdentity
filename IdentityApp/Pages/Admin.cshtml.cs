using IdentityApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Pages
{
    public class AdminModel : PageModel
    {
        public AdminModel(ProductDbContext ctx) => DbContext = ctx;

        public ProductDbContext DbContext { get; }

        public void OnGet()
        {
        }

        public IActionResult OnPost(long id) 
        { 
            Product p = DbContext.Find<Product>(id);
            if (p != null)
            {
                DbContext.Remove(p);
                DbContext.SaveChanges();
            }
            return Page();
        }
    }
}
