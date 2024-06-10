using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using HamzaProject.Models;

namespace HamzaProject.Pages
{
    public class StudentsModel : PageModel
    {
        private readonly DbAa7f76LibraryContext _context;

        public StudentsModel(DbAa7f76LibraryContext context)
        {
            _context = context;
        }

        public IList<Student> Students { get; set; }

        [BindProperty]
        public string StudentName { get; set; }

        [BindProperty]
        public string StudentNumber { get; set; }

        public async Task OnGetAsync()
        {
            Students = await _context.Students.ToListAsync();
        }

        public async Task<IActionResult> OnPostAddStudentAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var student = new Student
            {
                Name = StudentName,
                Number = StudentNumber
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
