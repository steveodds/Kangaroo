using System.Collections.Generic;

namespace Kangaroo.Managers
{
    public class MovieDetailsModel
    {
        public string status { get; set; }
        public string status_message { get; set; }

        public Data_MovieDetails data { get; set; }

        public class Data_MovieDetails
        {
            public Dictionary<string, dynamic> movie { get; set; }
        }
    }
}