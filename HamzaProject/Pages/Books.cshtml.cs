using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using HamzaProject.Models;

namespace HamzaProject.Pages
{
    public class BooksModel : PageModel
    {
        private readonly DbAa7f76LibraryContext _context;

        public BooksModel(DbAa7f76LibraryContext context)
        {
            _context = context;
        }

        public IList<Book> Books { get; set; }

        [BindProperty]
        public string BookName { get; set; }

        public async Task OnGetAsync()
        {
            Books = await _context.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostAddBookAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var book = new Book
            {
                Name = BookName
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
