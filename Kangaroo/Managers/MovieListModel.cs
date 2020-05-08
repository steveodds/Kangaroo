using System.Collections.Generic;

namespace Kangaroo.Managers
{
    public class MovieListModel
    {
        public string status { get; set; }
        public string status_message { get; set; }

        public Data_MovieList data { get; set; }

        public class Data_MovieList
        {
            public int movie_count { get; set; }
            public int limit { get; set; }
            public int page_number { get; set; }
            public Dictionary<string, dynamic>[] movies { get; set; }
        }
    }
}