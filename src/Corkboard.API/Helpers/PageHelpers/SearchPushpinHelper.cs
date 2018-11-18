using Corkboard.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Corkboard.API.Helpers.PageHelpers
{
    public static class SearchPushpinHelper
    {
        /// <summary>
        /// Returns the search results.
        /// </summary>
        public static List<SearchResults> GetResults(string query)
        {
            var searchedPushpinRows = DatabaseHelper.ExecuteQuery($"Select * from pushpin NATURAL JOIN Tags NATURAL JOIN corkboard " +
                $"where description LIKE '%{query}%' OR name LIKE '%{query}%' OR category_type LIKE '%{query}%' " +
                $"Order By description ASC");
            var searchResults = new List<SearchResults>();
            foreach (DataRow row in searchedPushpinRows.Rows)
            {
                // TODO - please update to contain the other properties within 'SearchResults'.
                searchResults.Add(new SearchResults(row.GetValueInRow("description"),
                    row.GetValueInRow("title"), row.GetValueInRow("name"), row.GetValueInRow("owner_email"), 
                    row.GetValueInRow("url"), row.GetValueInRow("date_time"), row.GetValueInRow("title")));
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
