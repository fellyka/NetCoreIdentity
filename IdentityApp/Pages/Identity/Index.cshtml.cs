using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityApp.Pages.Identity
{
    public class IndexModel : PageModel
    {
        public string? Email { get; set; }
        public string? Phone { get; set; }
       
    }
}
