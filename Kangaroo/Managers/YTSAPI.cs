using Kangaroo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Text.Json;

namespace Kangaroo.Managers
{
    public static class YTSAPI
    {
        private const string movieListUrl = "https://yts.mx/api/v2/list_movies.json";
        private const string movieDetailsUrl = "https://yts.mx/api/v2/movie_details.json";
        private const string movieSuggestionsUrl = "https://yts.mx/api/v2/movie_suggestions.json";
        public static async Task<MovieListModel> GetMovieListAsync(int resultLimit = 20)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(movieListUrl);
                var result = await client.GetAsync($"?limit={resultLimit}&sort_by=year");
                result.EnsureSuccessStatusCode();
                var resultContent = await result.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<MovieListModel>(resultContent);
            }
        }

        public static async Task<MovieDetailsModel> GetMovieDetailsAsync(int movieID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(movieDetailsUrl);
                var result = await client.GetAsync($"?movie_id={movieID}&with_images=true&with_cast=true");
                result.EnsureSuccessStatusCode();
                var resultContent = await result.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<MovieDetailsModel>(resultContent);
            }
        }

        public static async Task<MovieSuggestionsModel> GetMovieSuggestionsAsync(int movieID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(movieSuggestionsUrl);
                var result = await client.GetAsync($"?movie_id={movieID}");
                result.EnsureSuccessStatusCode();
                var resultContent = await result.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<MovieSuggestionsModel>(resultContent);
            }
        }
    }
}
