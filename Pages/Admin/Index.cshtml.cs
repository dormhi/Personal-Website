using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PersonalWebSite.Data;
using PersonalWebSite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalWebSite.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<ContactMessage> Messages { get; set; }

        public async Task OnGetAsync()
        {
            Messages = await _context.ContactMessages.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var msg = await _context.ContactMessages.FindAsync(id);
            if (msg != null)
            {
                _context.ContactMessages.Remove(msg);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Message deleted successfully.";
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToPage("/Index");
        }
    }
}
