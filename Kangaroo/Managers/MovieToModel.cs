using Kangaroo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;
using System.IO;

namespace Kangaroo.Managers
{
    public class MovieToModel
    {
        private List<MovieModel> _movies;
        private IWebHostEnvironment _environment;

        public MovieToModel(IWebHostEnvironment environment)
        {
            _movies = new List<MovieModel>();
            _environment = environment;
        }

        public List<MovieModel> PopulateList()
        {
            var jsonFile = File.ReadAllText(Path.Combine(_environment.ContentRootPath, "wwwroot/sets/movie_list.json"));
            var posterPath = Path.Combine(_environment.ContentRootPath, "wwwroot/sets/images/posters");
            var movieList = JsonSerializer.Deserialize<Dictionary<string, dynamic>[]>(jsonFile);

            foreach (var movie in movieList)
            {
                var tempMovie = new MovieModel()
                {
                    Id = movie["id"].GetInt32(),
                    Genres = JsonSerializer.Deserialize<string[]>(movie["genres"].GetRawText()),
                    ImdbId = movie["imdb_code"].GetString(),
                    Language = movie["language"].GetString(),
                    Poster = $"/sets/images/posters/{movie["id"].GetInt32()}.jpg",
                    Rating = movie["rating"].GetSingle(),
                    Runtime = movie["runtime"].GetInt32(),
                    Summary = movie["summary"].GetString(),
                    Title = movie["title_long"].GetString(),
                    TrailerLink = $"http://youtu.be/{movie["yt_trailer_code"].GetString()}",
                    Year = movie["year"].GetInt32()
                };
                _movies.Add(tempMovie);
            }
            return _movies;
        }
    }
}
