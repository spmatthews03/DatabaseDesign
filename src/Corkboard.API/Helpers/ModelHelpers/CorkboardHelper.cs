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
        /// Gets the corkboard.
        /// </summary>
        /// <param name="owner">Owner of the corkboard.</param>
        /// <param name="title">Title of the corkboard.</param>
        /// <returns>Returns the corkboard if it exists, null otherwise.</returns>
        public static Models.Corkboard GetCorkboard(User owner, string title)
        {
            return GetUserCorkboards(owner).FirstOrDefault(x => x.Title.Equals(title));
        }

        /// <summary>
        /// Gets the last time a pushpin was added to the corkboard.
        /// </summary>
        /// <param name="owner">Owner of the corkboard.</param>
        /// <param name="title">Title of the corkboard.</param>
        /// <returns>Returns the last time a pushpin was added to the corkboard, null otherwise.</returns>
        public static DateTime GetLatestCorkboardUpdate(this Models.Corkboard corkboard)
        {
            var results = DatabaseHelper.ExecuteQuery($"SELECT date_time FROM pushpin WHERE owner_email = '{corkboard.Owner.Email}' AND title = '{corkboard.Title}' ORDER BY date_time DESC LIMIT 1");
            var update = (results.Rows.Count > 0) ? Convert.ToDateTime(results.GetValueInTable("date_time")) : DateTime.MinValue;
            return update;
        }

        /// <summary>
        /// Returns the list of recently updated corkboards. This includes strictly includes the corkboards
        /// the current user follows or watches.
        /// </summary>
        /// <param name="currentUser">User to use for following/watching.</param>
        /// <returns>Returns the list of corkboards, or an empty list.</returns>
        public static List<Models.Corkboard> GetRecentUpdatedCorkboards(User currentUser)
        {
            var maxQuery = $"SELECT owner_email, title, MAX(date_time) FROM pushpin NATURAL GROUP BY owner_email, title";

            var recentUpdates = DatabaseHelper.ExecuteQuery($"SELECT corkboard.*, MAX(pushpin.date_time) AS 'LastUpdated' FROM pushpin " +
                $"NATURAL JOIN corkboard " +
                $"GROUP BY pushpin.owner_email, pushpin.title " +
                $"ORDER BY MAX(pushpin.date_time) DESC LIMIT 4");

            var corkboardList = new List<Models.Corkboard>();
            foreach (DataRow row in recentUpdates.Rows)
            {
                corkboardList.Add(CreateCorkboardFromDataRow(row));
            }
            return corkboardList;
        }

        /// <summary>
        /// Returns the list of corkboards the user created.
        /// </summary>
        /// <param name="user">User to retrieve corkboards for.</param>
        /// <returns></returns>
        public static List<Models.Corkboard> GetUserCorkboards(User user)
        {
            var corkboardRows = DatabaseHelper.ExecuteQuery($"Select * from corkboard where owner_email = '{user.Email}'");
            var corkboardList = new List<Models.Corkboard>();
            foreach (DataRow row in corkboardRows.Rows)
            {
                corkboardList.Add(CreateCorkboardFromDataRow(row));
            }

            return corkboardList;
        }

        public static List<Models.User> GetCorkboardWatchers(Models.Corkboard corkboard)
        {
            var watchers = DatabaseHelper.ExecuteQuery($"Select * from Corkboard NATURAL JOIN Watch WHERE owner_email='{corkboard.Owner.Email}' AND title='{corkboard.Title}'");
            var watchersList = new List<Models.User>();
            foreach (DataRow row in watchers.Rows)
            {
                watchersList.Add(UserHelper.GetUserByEmail(row.GetValueInRow("email")));
            }
            return watchersList;
        }

        /// <summary>
        /// Validates the password for the corkboard.
        /// </summary>
        /// <param name="title">Title of the corkboard.</param>
        /// <param name="ownerEmail">Owner's email of the corkboard.</param>
        /// <param name="password">Attempted password of the corkboard.</param>
        public static bool CanViewCorkboard(string title, string ownerEmail, string password)
        {
            var passwordRow = DatabaseHelper.ExecuteQuery($"Select password from private_corkboard NATURAL JOIN Corkboard where owner_email='{ownerEmail}' AND title='{title}'");
            var corkboardPassword = passwordRow.GetValueInTable("password");
            if(corkboardPassword == password)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Gets the user's public corkboards.
        /// </summary>
        /// <param name="user">User to retrieve public corkboards for.</param>
        public static List<Models.Corkboard> GetUserPublicCorkboards(User user)
        {
            return GetUserCorkboards(user);
        }

        public static Models.Corkboard CreateCorkboardFromDataRow(DataRow row)
        {
            var corkboard = new Models.Corkboard();
            corkboard.Category = row.GetValueInRow("category_type");
            corkboard.IsPrivate = GetCorkboardVisibility(row.GetValueInRow("visibility"));
            corkboard.Title = row.GetValueInRow("title");
            corkboard.Owner = UserHelper.GetUserByEmail(row.GetValueInRow("owner_email"));
            corkboard.Pushpins = PushpinHelper.GetPushpinsForCorkboard(corkboard);
            corkboard.LastUpdate = Convert.ToDateTime(corkboard.GetLatestCorkboardUpdate());
            corkboard.Watchers = GetCorkboardWatchers(corkboard);

            return corkboard;
        }

        #region Private

        private static bool GetCorkboardVisibility(string isPrivate)
        {
            if (isPrivate.Equals("False"))
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
