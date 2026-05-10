using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PersonalWebSite.Pages.Admin
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Simple hardcoded check
            if (Username == "dormhi" && Password == "dormhi")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Username),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var claimsIdentity = new ClaimsIdentity(claims, "MyCookieAuth");
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                await HttpContext.SignInAsync("MyCookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    return RedirectToPage("/Admin/Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return Page();
        }
    }
}
