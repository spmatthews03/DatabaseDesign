﻿using Corkboard.API.Models;
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
            return null;
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

        /// <summary>
        /// Gets the user's public corkboards.
        /// </summary>
        /// <param name="user">User to retrieve public corkboards for.</param>
        public static List<Models.Corkboard> GetUserPublicCorkboards(User user)
        {
            return GetUserCorkboards(user).Where(x => x.IsPrivate.Equals(false)).ToList();
        }

        public static Models.Corkboard CreateCorkboardFromDataRow(DataRow row)
        {
            var corkboard = new Models.Corkboard();
            corkboard.Category = row.GetValueInRow("category");
            corkboard.LastUpdate = Convert.ToDateTime(row.GetValueInRow("LastUpdate"));
            corkboard.IsPrivate = GetCorkboardVisibility(row.GetValueInRow("visibility"));
            corkboard.Title = row.GetValueInRow("title");
            corkboard.Pushpins = PushpinHelper.GetPushpinsForCorkboard(corkboard);

            return corkboard;
        }

        #region Private

        private static bool GetCorkboardVisibility(string isPrivate)
        {
            if (isPrivate.Equals("0"))
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
