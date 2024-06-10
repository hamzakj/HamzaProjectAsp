using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using HamzaProject.Models;

namespace HamzaProject.Pages
{
    public class BorrowModel : PageModel
    {
        private readonly DbAa7f76LibraryContext _context;

        public BorrowModel(DbAa7f76LibraryContext context)
        {
            _context = context;
        }

        public IList<Book> Books { get; set; }
        public IList<Student> Students { get; set; }
        public IList<StudentBorrow> StudentBorrows { get; set; }

        [BindProperty]
        public int StudentId { get; set; }

        [BindProperty]
        public int BookId { get; set; }

        public async Task OnGetAsync()
        {
            Books = await _context.Books.ToListAsync();
            Students = await _context.Students.ToListAsync();
            StudentBorrows = await _context.StudentBorrows
                .Include(sb => sb.Student)
                .Include(sb => sb.Book)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostBorrowBookAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var studentBorrow = new StudentBorrow
            {
                StudentId = StudentId,
                BookId = BookId,
                BookStatus = 1 // Assuming we have a Status property in StudentBorrow
            };

            _context.StudentBorrows.Add(studentBorrow);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostChangeStatusAsync([FromBody] StatusChangeRequest request)
        {
            var borrow = await _context.StudentBorrows.FindAsync(request.Id);
            if (borrow == null)
            {
                return NotFound();
            }

            borrow.BookStatus = (byte) request.Status;
            await _context.SaveChangesAsync();

            return new JsonResult(new { success = true });
        }

        public class StatusChangeRequest
        {
            public int Id { get; set; }
            public int Status { get; set; }
        }
    }
}
