using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corkboard.API.Helpers.PageHelpers
{
    public static class PopularSitesHelper
    {
        /// <summary>
        /// Returns the popular sites.
        /// </summary>
        public static List<Models.Sites> GetPopularSites()
        {
            // TODO - we should not limit this
            var results = DatabaseHelper.ExecuteQuery("SELECT url AS Site, COUNT(*) AS PushPins FROM pushpin WHERE tags IS NOT NULL GROUP BY url ORDER BY COUNT(*) DESC; ");
            var sites = new List<Models.Sites>();
            foreach (DataRow row in results.Rows)
            {
                var url = row.GetValueInRow("Site");
                var pushpins = Convert.ToInt32(row.GetValueInRow("PushPins"));

                sites.Add(new Models.Sites(pushpins, url));
            }

            return sites;

        }
    }
}
