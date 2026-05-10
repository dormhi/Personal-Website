using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebSite.Data;
using PersonalWebSite.Models;
using System.Threading.Tasks;

namespace PersonalWebSite.Pages
{
    public class ContactModel : PageModel
    {
        private readonly AppDbContext _context;

        public ContactModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContactMessage ContactMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save to SQLite
            _context.ContactMessages.Add(ContactMessage);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Mesajınız başarıyla alındı. En kısa sürede dönüş yapacağım.";
            
            return RedirectToPage("/Contact");
        }
    }
}
