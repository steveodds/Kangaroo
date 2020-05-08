using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kangaroo.Managers
{
    public class MovieHandler
    {
        public static int GetMovieID(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("The title given was an invalid movie title.");

            var tempHandler = new MovieHandler(title);

            return 0;
        }

        public int MovieID { get; set; }
        public Guid MovieGUID { get; set; }
        public string MovieTitle { get; private set; }
        private string searchTitle;

        public MovieHandler(string title)
        {
            searchTitle = title;
            if (!GetDetailsBySearchString())
                throw new Exception("Failed to fetch movie details");
        }

        public MovieHandler(Guid movieGuid)
        {
            MovieGUID = movieGuid;
            if (!GetDetailsByGuid())
                throw new ArgumentException("No movie matches the given GUID");
        }

        private bool GetDetailsByGuid()
        {
            throw new NotImplementedException();
        }

        private bool GetDetailsBySearchString()
        {
            if (string.IsNullOrEmpty(searchTitle))
                throw new ArgumentException("An invalid string was passed: Search string should not be empty.");

            return true;
        }
    }
}
