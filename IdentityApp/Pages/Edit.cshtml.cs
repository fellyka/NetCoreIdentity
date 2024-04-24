using IdentityApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly ProductDbContext DbContext;

        public EditModel(ProductDbContext ctx) => DbContext = ctx;
        public Product Product { get; set; }

        public void OnGet(long id)
        {
            Product = DbContext.Find<Product>(id) ?? new Product();
        }

        public IActionResult OnPost([Bind(Prefix = "Product")] Product p)
        {
            DbContext.Update(p);
            DbContext.SaveChanges();
            return RedirectToPage("Admin");
        }
    }
}
