using IdentityApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Pages
{
    public class StoreModel : PageModel
    {
        public readonly ProductDbContext DbContext;

        public StoreModel(ProductDbContext ctx) => DbContext = ctx;
        
        public void OnGet()
        {
        }
    }
}
