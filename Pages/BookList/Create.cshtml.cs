using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookListRazor.Models;

namespace BookListRazor
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public CreateModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public string Message { get; set; }

        public void OnGet()
        {

        }
        
        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            _dbContext.Book.Add(Book);
            await _dbContext.SaveChangesAsync();

            Message = "Book has been created successfully!";

            return RedirectToPage("Index");
        }
    }
}