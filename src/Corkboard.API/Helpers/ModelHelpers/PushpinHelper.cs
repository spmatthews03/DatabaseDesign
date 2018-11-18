using Corkboard.API.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Corkboard.API.Helpers
{
    public static class PushpinHelper
    {
        public static List<Models.Pushpin> GetPushpinsForCorkboard(Models.Corkboard corkboard)
        {
            var pushpinRows = DatabaseHelper.ExecuteQuery($"Select * From pushpin where owner_email = '{corkboard.Owner.Email}' AND title = '{corkboard.Title}'");
            return CreatePushpinsFromDataRows(pushpinRows.Rows);
        }

        public static Models.Corkboard GetCorkboardPushpinIsOn(Pushpin pushpin)
        {
            var pushpinRows = DatabaseHelper.ExecuteQuery($"Select * From corkboard where owner_email = '{pushpin.Owner_Email}' AND title = '{pushpin.Title}'");
            return CorkboardHelper.CreateCorkboardFromDataRow(pushpinRows.Rows[0]);
        }

        /// <summary>
        /// Gets all the public pushpins.
        /// </summary>
        public static List<Models.Pushpin> GetAllPushpins()
        {
            var allPushpinsTable = DatabaseHelper.ExecuteQuery($"Select * From pushpin");
            return CreatePushpinsFromDataRows(allPushpinsTable.Rows);
        }

        /// <summary>
        /// Gets all the public pushpins.
        /// </summary>
        public static List<Models.Pushpin> GetPublicPushpins()
        {
            var allPushpins = GetAllPushpins();

            var publicPushpins = new List<Pushpin>();
            foreach(var pushpin in allPushpins)
            {
                if (!GetCorkboardPushpinIsOn(pushpin).IsPrivate)
                {
                    publicPushpins.Add(pushpin);
                }
            }

            return publicPushpins;
        }

        public static List<string> GetTagsForPushpin(string corkboardTitle, string dateTime, string userEmail, string url)
        {
            var tagResults = DatabaseHelper.ExecuteQuery($"Select * from tags where " +
                    $"title = '{corkboardTitle}' AND " +
                    $"date_time = '{dateTime}' AND " +
                    $"owner_email = '{userEmail}' AND " +
                    $"url = '{url}'");

            return tagResults.Rows.GetValueInRows("Name");
        }

        /// <summary>
        /// Gets the pushpin.
        /// </summary>
        public static Pushpin GetPushpin(string title, string ownerEmail, string url, string dateTime)
        {
            return null;
        }

        /// <summary>
        /// Likes the pushpin.
        /// </summary>
        /// <param name="pushpin">Pushpin to like.</param>
        /// <param name="user">User to add to the like table.</param>
        public static void LikePushpin(Pushpin pushpin, User user)
        {
            DatabaseHelper.ExecuteQuery($"INSERT INTO `Like` (email, date_time, url, title, owner_email) " +
                $"VALUES('{user.Email}','{pushpin.DateTime}','{pushpin.Url}','{pushpin.Title}','{pushpin.Owner_Email}')");
        }

        /// <summary>
        /// Unlikes the pushpin.
        /// </summary>
        /// <param name="pushpin">Pushpin to unlike.</param>
        /// <param name="user">User to remove from the likes table.</param>
        public static void UnlikePushpin(Pushpin pushpin, User user)
        {
            DatabaseHelper.ExecuteQuery($"DELETE FROM `Like` WHERE email='{user.Email}' AND date_time='{pushpin.DateTime}' " +
                $"AND url='{pushpin.Url} AND title='{pushpin.Title}' AND owner_email='{pushpin.Owner_Email}'");
        }

        /// <summary>
        /// Adds a comment to the pushpin. Date/Time needs to be recorded.
        /// </summary>
        /// <param name="pushpin">Pushpin to add the comment to.</param>
        /// <param name="user">User adding the comment.</param>
        /// <param name="comment">Comment being added.</param>
        public static void AddComment(Pushpin pushpin, User user, string comment)
        {
            DatabaseHelper.ExecuteQuery($"INSERT INTO Comment (date_time, text, email, url, title, owner_email, pushpin, date_time) " +
                $"Values(NOW(),'{comment}','{user.Email}','{pushpin.Url}','{pushpin.Title}','{pushpin.Owner_Email}','{pushpin.DateTime}')");
        }

        #region Private

        private static Models.Pushpin CreatePushpinFromDataRow(DataRow row)
        {
            var description = row.GetValueInRow("Description");
            var url = row.GetValueInRow("Url");
            var dateTime = row.GetValueInRow("date_time");
            var title = row.GetValueInRow("title");
            var owner_email = row.GetValueInRow("owner_email");
            var tags = GetTagsForPushpin(title, dateTime, owner_email, url);

            return new Models.Pushpin(title, dateTime, owner_email, description, url, tags);
        }

        private static List<Pushpin> CreatePushpinsFromDataRows(DataRowCollection rows)
        {
            var pushpinList = new List<Pushpin>();
            foreach (DataRow row in rows)
            {
                var pushpin = CreatePushpinFromDataRow(row);
                pushpinList.Add(pushpin);
            }

            return pushpinList;
        }
        #endregion
    }
}
