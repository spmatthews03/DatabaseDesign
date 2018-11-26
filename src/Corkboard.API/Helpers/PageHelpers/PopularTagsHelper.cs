using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corkboard.API.Models;


namespace Corkboard.API.Helpers.PageHelpers
{
    public static class PopularTagsHelper
    {
        /// <summary>
        /// Returns the popular tags.
        /// </summary>
        public static List<Models.PopularTags> GetPopularTags()
        {
            // TODO - this should not be limited
            var popularTagRows = DatabaseHelper.ExecuteQuery($"Select name," +
                $" Count(Distinct date_time, owner_email, url, title) AS Pushpins," +
                $" Count(Distinct Tags.title, owner_email) AS 'Unique Corkboards'" +
                $" from tags NATURAL JOIN corkboard" +
                $" Group By name " +
                $"ORDER BY Count(Distinct date_time, owner_email, url, title) DESC, " +
                $"Count(Distinct Tags.title, owner_email) DESC LIMIT 5");

            var popularTagList = new List<Models.PopularTags>();
            foreach (DataRow row in popularTagRows.Rows)
            {
                var name = row.GetValueInRow("name");
                var numPushPins = Int32.Parse(row.GetValueInRow("Pushpins"));
                var uniqCorkboards = Int32.Parse(row.GetValueInRow("Unique Corkboards"));

                popularTagList.Add(new PopularTags(name, numPushPins,uniqCorkboards));
            }

            return popularTagList;
        }
    }
}
