using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kangaroo.Models;

namespace Kangaroo.Pages
{
    public class TitleModel : PageModel
    {
        private readonly Kangaroo.Models.MovieContext _context;

        public TitleModel(Kangaroo.Models.MovieContext context)
        {
            _context = context;
        }

        public MovieModel MovieModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieModel = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if (MovieModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
