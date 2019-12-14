using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookListRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public IndexModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Book> Books { get; set; }

        [TempData]
        public string Message { get; set; }
        
        public async Task OnGet()
        {
            Books = await _dbContext.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _dbContext.Book.FindAsync(id);

            if (book == null)
                return NotFound(); ;

            _dbContext.Book.Remove(book);
            await _dbContext.SaveChangesAsync();

            Message = "Book is deleted successfully!";

            return RedirectToPage("Index");

        }
    }
}