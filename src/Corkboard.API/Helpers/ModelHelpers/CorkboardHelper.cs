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
        /// Returns the list of recently updated corkboards. This includes strictly includes the corkboards
        /// the current user follows or watches.
        /// </summary>
        /// <param name="currentUser">User to use for following/watching.</param>
        /// <returns>Returns the list of corkboards, or an empty list.</returns>
        public static List<Models.Corkboard> GetRecentUpdatedCorkboards(User currentUser)
        {
            var recentUpdates = DatabaseHelper.ExecuteQuery($"Select * from (corkboard NATURAL JOIN Users) " +
                $"NATURAL JOIN pushpin where (corkboard.owner_email IN (Select Follows.follower_email from Follows WHERE Follows.email='{currentUser.Email}' " +
                $"UNION Select Watch.owner_email from Watch WHERE Watch.email='{currentUser.Email}') OR corkboard.owner_email='{currentUser.Email}') AND corkboard.owner_email=Users.email " +
                $"Group By corkboard.title Order By pushpin.date_time DESC Limit 4");


            var corkboardList = new List<Models.Corkboard>();
            foreach (DataRow row in recentUpdates.Rows)
            {
                // TODO: fix this... shouldn't call CreateCorkboard
                // corkboardList.Add(CreateCorkboardFromDataRow(row));
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
            var corkboardRows = DatabaseHelper.ExecuteQuery($"Select * from corkboard NATURAL LEFT OUTER JOIN pushpin where owner_email = '{user.Email}' GROUP BY title");
            var corkboardList = new List<Models.Corkboard>();
            foreach (DataRow row in corkboardRows.Rows)
            {
                corkboardList.Add(CreateCorkboardFromDataRow(row));
            }

            return corkboardList;
        }


        public static List<Models.User> GetNumberOfWatchersCorkboards(Models.Corkboard corkboard)
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
            // TODO - if password is correct, return true. False otherwise.
            return false;
        }


        /// <summary>
        /// Gets the user's public corkboards.
        /// </summary>
        /// <param name="user">User to retrieve public corkboards for.</param>
        public static List<Models.Corkboard> GetUserPublicCorkboards(User user)
        {
            // return GetUserCorkboards(user).Where(x => x.IsPrivate.Equals(false)).ToList();
            return GetUserCorkboards(user);
        }

        public static Models.Corkboard CreateCorkboardFromDataRow(DataRow row)
        {
            var corkboard = new Models.Corkboard();
            corkboard.Category = row.GetValueInRow("category_type");
            // corkboard.LastUpdate = Convert.ToDateTime(row.GetValueInRow("LastUpdate"));
            if(!row.GetValueInRow("date_time").Equals(""))
            {
                corkboard.LastUpdate = Convert.ToDateTime(row.GetValueInRow("date_time"));
            }
            corkboard.IsPrivate = GetCorkboardVisibility(row.GetValueInRow("visibility"));
            corkboard.Title = row.GetValueInRow("title");
            corkboard.Owner = UserHelper.GetUserByEmail(row.GetValueInRow("owner_email"));
            corkboard.Pushpins = PushpinHelper.GetPushpinsForCorkboard(corkboard);
            corkboard.Watchers = GetNumberOfWatchersCorkboards(corkboard);

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
