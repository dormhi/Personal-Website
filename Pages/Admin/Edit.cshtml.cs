using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebSite.Data;
using PersonalWebSite.Models;
using System.Threading.Tasks;

namespace PersonalWebSite.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContactMessage ContactMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ContactMessage = await _context.ContactMessages.FindAsync(id);

            if (ContactMessage == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ContactMessage).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Message updated successfully.";
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                if (!ContactMessageExists(ContactMessage.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ContactMessageExists(int id)
        {
            return _context.ContactMessages.Any(e => e.Id == id);
        }
    }
}
