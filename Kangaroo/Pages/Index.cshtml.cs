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
        private readonly MovieToModel _movieToModel;
        public List<MovieModel> movies { get; set; }

        public IndexModel(ILogger<IndexModel> logger, CacheLoader cacheLoader, MovieToModel movieToModel)
        {
            _logger = logger;
            _cacheLoader = cacheLoader;
            _movieToModel = movieToModel;

            _cacheLoader.APIToCache();
            movies = _movieToModel.PopulateList();
        }

        public void OnGet()
        {

        }
    }
}
