using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace Kangaroo.Managers
{
    public class CacheLoader
    {
        private readonly IWebHostEnvironment _environment;
        private readonly MovieListModel movieList;
        public CacheLoader(IWebHostEnvironment environment)
        {
            _environment = environment;
            movieList = YTSAPI.GetMovieListAsync(50).Result;
        }
        public void APIToCache()
        {
            string cachePath = Path.Combine(_environment.ContentRootPath, "wwwroot/sets/movie_list.json");
            if (!File.Exists(cachePath))
            {
                var movies = movieList.data.movies;
                var tempJson = JsonSerializer.Serialize(movies);
                File.AppendAllText(cachePath, tempJson);
            }

            MoviePostersToCache();
        }

        private void MoviePostersToCache()
        {
            var movies = movieList.data.movies;

            foreach (var movie in movies)
            {
                var localImage = Path.Combine(_environment.ContentRootPath, $"wwwroot/sets/images/posters/{movie["id"]}.jpg");
                if (!File.Exists(localImage))
                {
                    var imageUrl = Convert.ToString(movie["large_cover_image"]);
                    using var client = new WebClient();
                    client.DownloadFile(imageUrl, localImage);
                }
            }
        }
    }
}
