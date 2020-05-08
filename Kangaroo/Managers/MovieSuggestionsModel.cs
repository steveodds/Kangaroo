using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kangaroo.Managers
{
    public class MovieSuggestionsModel
    {
        public string status { get; set; }
        public string status_message { get; set; }

        public Data_MovieSuggestions data { get; set; }

        public class Data_MovieSuggestions
        {
            public int movie_count { get; set; }
            public Dictionary<string, dynamic>[] movies { get; set; }

        }

    }
}
