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
            var matchingPushpins = GetMatchingPushpins(query);

            var searchResults = new List<SearchResults>();
            foreach(var pushpin in matchingPushpins)
            {
                var corkboard = PushpinHelper.GetCorkboardPushpinIsOn(pushpin);
                searchResults.Add(new SearchResults(pushpin.Description, corkboard.Title, corkboard.Owner.Name));         
            }
            
            return searchResults;
        }

        /// <summary>
        /// Returns the search results.
        /// </summary>
        public static List<Pushpin> GetMatchingPushpins(string query)
        {
            ///Gets all pushpins on public corkboards
            var publicPushpins = PushpinHelper.GetPublicPushpins();

            var matchingPushpins = new List<Pushpin>();
            foreach (var pushpin in publicPushpins)
            {
                ///Searches the pushpin description for a match.
                if (pushpin.Description.Contains(query))
                {
                    matchingPushpins.Add(pushpin);
                }
                ///Searches the pushpin tags for a match.
                else if (pushpin.Tags.Any(x => x.Contains(query)))
                {
                    matchingPushpins.Add(pushpin);
                }
                ///Searches the corkboard category for a match.
                else if (PushpinHelper.GetCorkboardPushpinIsOn(pushpin).Category.Contains(query))
                {
                    matchingPushpins.Add(pushpin);
                }
            }

            return matchingPushpins;
        }
    }
}
