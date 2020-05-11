using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kangaroo.Managers;
using Kangaroo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Kangaroo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CacheLoader _cacheLoader;
        public List<MovieModel> movies { get; set; }

        public IndexModel(ILogger<IndexModel> logger, CacheLoader cacheLoader)
        {
            _logger = logger;
            _cacheLoader = cacheLoader;
            _cacheLoader.APIToCache();

            movies = _cacheLoader.LoadMoviesAsync().Result;
        }

        public void OnGet()
        {

        }
    }
}
