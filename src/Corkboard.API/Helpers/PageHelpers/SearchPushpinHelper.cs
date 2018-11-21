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
            var searchedPushpinRows = DatabaseHelper.ExecuteQuery($"SELECT title, description, users.name AS name, owner_email, url, date_time " +
                $"FROM pushpin NATURAL JOIN corkboard NATURAL LEFT OUTER JOIN tags JOIN users ON corkboard.owner_email = users.email " +
                $"WHERE corkboard.visibility = 0 AND " +
                $"(pushpin.description LIKE '%{query}%' OR corkboard.category_type LIKE '%{query}%' OR tags.name LIKE '%{query}%') " +
                $"GROUP BY pushpin.title, pushpin.owner_email, pushpin.date_time, pushpin.url " +
                $"ORDER BY description ASC");

            var searchResults = new List<SearchResults>();
            foreach (DataRow row in searchedPushpinRows.Rows)
            {
                // TODO - please update to contain the other properties within 'SearchResults'.
                searchResults.Add(new SearchResults(row.GetValueInRow("title"), row.GetValueInRow("description"), row.GetValueInRow("name"), row.GetValueInRow("owner_email"), 
                    row.GetValueInRow("url"), row.GetValueInRow("date_time"), row.GetValueInRow("title")));
            }

            return searchResults;
        }
    }
}
