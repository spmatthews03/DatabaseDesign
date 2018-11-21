using System.Collections.Generic;
using System.Data;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corkboard.API.Models;

namespace Corkboard.API.Helpers.ModelHelpers
{
    public static class StatHelper
    {
        /// <summary>
        /// Returns all stats for all users and their corkboards.
        /// </summary>
        public static List<Models.Stats> GetCorkboardStats()
        {
            var statsRows = DatabaseHelper.ExecuteQuery($"SELECT name," +
                $"Count(DISTINCT corkboard.title, corkboard.owner_email) - Count(DISTINCT corkboard.title, corkboard.owner_email, password) AS 'Public Corkboards'," +
                $"COUNT(Pushpin.date_time)-COUNT(Private_Corkboard.owner_email) AS 'Public PushPins'," +
                $"COUNT(Distinct Private_Corkboard.title, Private_Corkboard.owner_email) AS 'Private Corkboards'," +
                $"COUNT(DISTINCT Private_Corkboard.owner_email, pushpin.url) AS 'Private PushPins'" +
                $"FROM((Corkboard NATURAL JOIN Users) NATURAL LEFT OUTER JOIN Private_Corkboard) NATURAL LEFT OUTER JOIN Pushpin" +
                $" wHERE Corkboard.owner_email = Users.email" +
                $" GROUP BY name " +
                $"ORDER BY COUNT(DISTINCT Corkboard.title, Corkboard.owner_email) DESC");

            var statsList = new List<Models.Stats>();
            foreach (DataRow row in statsRows.Rows)
            {
                var name = row.GetValueInRow("name");
                var numPubCorkboards = Int32.Parse(row.GetValueInRow("Public Corkboards"));
                var numPubPushPins = Int32.Parse(row.GetValueInRow("Public PushPins"));
                var numPrivCorkboards = Int32.Parse(row.GetValueInRow("Private Corkboards"));
                var numPrivPushPins = Int32.Parse(row.GetValueInRow("Private PushPins"));

                statsList.Add(new Models.Stats(name, numPubCorkboards, numPubPushPins, numPrivCorkboards, numPrivPushPins));
            }

            return statsList;




            return null;
        }
    }
}
