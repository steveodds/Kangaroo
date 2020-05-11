using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Kangaroo.Models;
using Microsoft.EntityFrameworkCore;

namespace Kangaroo.Managers
{
    public class CacheLoader
    {
        private readonly IWebHostEnvironment _environment;
        private readonly MovieContext _context;
        private readonly MovieToModel _model;
        private readonly MovieListModel movieList;
        public CacheLoader(IWebHostEnvironment environment, MovieContext context, MovieToModel model)
        {
            _environment = environment;
            _context = context;
            _model = model;
            movieList = YTSAPI.GetMovieListAsync(50).Result;
        }

        public async Task<List<MovieModel>> LoadMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public void APIToCache()
        {
            string cachePath = Path.Combine(_environment.ContentRootPath, "wwwroot/sets/movie_list.json");
            if (!File.Exists(cachePath))
            {
                var movies = movieList.data.movies;
                var tempJson = JsonSerializer.Serialize(movies);
                File.AppendAllText(cachePath, tempJson);
                SaveMovies(_model.PopulateList());
            }
            MoviePostersToCache();
        }

        private async void SaveMovies(List<MovieModel> movies)
        {
            foreach (var movie in movies)
            {
                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();
            }
        }

        private void MoviePostersToCache()
        {
            var movies = movieList.data.movies;

            foreach (var movie in movies)
            {
                var localImage = Path.Combine(_environment.ContentRootPath, $"wwwroot/sets/images/posters/{movie["id"]}.jpg");
                if (!File.Exists(localImage))
                {
                    string imageUrl = Convert.ToString(movie["large_cover_image"]);
                    using var client = new WebClient();
                    client.DownloadFileAsync(new Uri(imageUrl), localImage);
                }
            }
        }
    }
}
