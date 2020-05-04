using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kangaroo.Models
{
    public class MovieModel
    {
        public Guid Id { get; set; }
        public string ImdbId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public float Rating { get; set; }
        public int Runtime { get; set; }
        public string[] Genres { get; set; }
        public string Summary { get; set; }
        public string TrailerLink { get; set; }
        public string Language { get; set; }
        public string Poster { get; set; }
    }
}
