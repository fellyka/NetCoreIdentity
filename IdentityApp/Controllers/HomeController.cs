using IdentityApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers
{
    public class HomeController : Controller
    {
        /*This controller present the first level of access, which is available to anyone*/
       
        private ProductDbContext DbContext;
        public HomeController(ProductDbContext ctx) => DbContext = ctx;
        public IActionResult Index() => View(DbContext.Products);
        
    }
}
