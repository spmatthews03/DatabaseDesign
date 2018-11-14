using System.Collections.Generic;
using System.Data;

namespace Corkboard.API.Helpers
{
    public static class PushpinHelper
    {
        public static List<Models.Pushpin> GetPushpinsForCorkboard()
        {
            var pushpinRows = DatabaseHelper.ExecuteQuery("GET ALL PUSHPINS FOR CORKBOARD");
            var pushpinsList = new List<Models.Pushpin>();
            foreach (DataRow row in pushpinRows.Rows)
            {
                var pushpin = new Models.Pushpin();
                pushpin.Description = row.GetValueInRow("Description");
                pushpin.Url = row.GetValueInRow("Url");
                pushpinsList.Add(pushpin);
            }

            return pushpinsList;
        }

        /// <summary>
        /// Gets all the pushpins where the description OR tags OR category CONTAINS the query.
        /// Does not need to be an exact match.
        /// </summary>
        public static List<Models.Pushpin> GetPushpins(string query)
        {
            return null;
        }
    }
}
