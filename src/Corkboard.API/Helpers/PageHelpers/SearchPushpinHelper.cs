using Corkboard.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Corkboard.API.Helpers.PageHelpers
{
    public static class SearchPushpinHelper
    {
        /// <summary>
        /// Returns the search results.
        /// </summary>
        public static List<SearchResults> GetResults(string query)
        {
            var matchingPushpins = PushpinHelper.GetPushpins(query);
            return null;
        }
    }
}
