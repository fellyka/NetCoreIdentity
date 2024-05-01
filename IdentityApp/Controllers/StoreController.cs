using IdentityApp.Model;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        private readonly ProductDbContext DbContext;

        public StoreController(ProductDbContext ctx) => DbContext = ctx;
       
        public IActionResult Index() => View(DbContext.Products);
    }
}
