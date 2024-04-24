using IdentityApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Pages
{
    public class LandingModel : PageModel
    {
        public readonly ProductDbContext DbContext;

        public LandingModel(ProductDbContext ctx) => DbContext = ctx;

        public void OnGet()
        {
        }
    }
}
