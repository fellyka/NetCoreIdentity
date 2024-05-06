using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityApp.Pages.Identity.Admin
{
    public class DashboardModel : PageModel
    {
        public DashboardModel(UserManager<IdentityUser> userMgr)
          => UserManager = userMgr;
        /*IdentityUser is a default class supplied by Microsoft but we can create our own by inheriting from this one*/
        public UserManager<IdentityUser> UserManager { get; set; }
        public int UsersCount { get; set; } = 0;
        public int UsersUnconfirmed { get; set; } = 0;
        public int UsersLockedout { get; set; } = 0;
        public int UsersTwoFactor { get; set; } = 0;

        private readonly string[] emails = { "alice@example.com", "bob@example.com", "charlie@example.com"};

        public async Task<IActionResult> OnPostAsync()
        {
            foreach(string email in emails)
            {
                /*The type of the user class is specified using the generic type argument to the AddDefaultIdentity method in the Program.cs- That type is IdentityUser
                  The user class defines a set of properties that describe the user account and provide the data values that Identity needs to implement its features.
                  To create a new user object, I create a new instance of the IdentityUser class and set three properties UserName, Email, and EmailConfirmed
                 */
                IdentityUser userObject = new IdentityUser
                {
                    UserName = email, //The email is used for both, UserName and Email
                    Email = email,
                    EmailConfirmed = true
                };
              IdentityResult result =  await UserManager.CreateAsync(userObject);
                result.Process(ModelState);
            }
            if(ModelState.IsValid)
            {
                return RedirectToPage();
            }

            return Page();
          
        }


    }
}
