using Corkboard.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Corkboard.API.Helpers
{
    public static class CorkboardHelper
    {
        /// <summary>
        /// Returns the list of recently updated corkboards. This includes strictly includes the corkboards
        /// the current user follows or watches.
        /// </summary>
        /// <param name="currentUser">User to use for following/watching.</param>
        /// <returns>Returns the list of corkboards, or an empty list.</returns>
        public static List<Models.Corkboard> GetRecentUpdatedCorkboards(User currentUser)
        {
            return null;
        }

        /// <summary>
        /// Returns the list of corkboards the current user created.
        /// </summary>
        /// <param name="currentUser">User to retrieve corkboards for.</param>
        /// <returns></returns>
        public static List<Models.Corkboard> GetUsersCorkboards(User currentUser)
        {
            var corkboardRows = DatabaseHelper.ExecuteQuery("GET ALL CORKBOARDS FOR USER");
            var corkboardList = new List<Models.Corkboard>();
            foreach (DataRow row in corkboardRows.Rows)
            {
                var newCorkboad = new Models.Corkboard();
                newCorkboad.Category = row.GetValueInRow("Category");
                newCorkboad.LastUpdate = Convert.ToDateTime(row.GetValueInRow("LastUpdate"));
                newCorkboad.Title = row.GetValueInRow("Title");
                newCorkboad.Pushpins = PushpinHelper.GetPushpinsForCorkboard();
                corkboardList.Add(newCorkboad);
            }

            return corkboardList;
        }

        public static List<Models.Corkboard> GetUsersPublicCorkboards(User user)
        {
            return GetUsersCorkboards(user).Where(x => x.IsPrivate.Equals(false)).ToList();
        }
    }
}
