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
                $"COUNT(Distinct Corkboard.title, Corkboard.owner_email) AS 'Public Corkboards'," +
                $"COUNT(PushPin.date_time) AS 'Public PushPins'," +
                $"COUNT(Distinct Private_Corkboard.title, Private_Corkboard.owner_email) AS 'Private Corkboards'," +
                $"COUNT(Private_Corkboard.owner_email) AS 'Private PushPins'" +
                $"FROM ((Corkboard NATURAL JOIN User) NATURAL JOIN Pushpin)" +
                $"LEFT JOIN Private_Corkboard ON Corkboard.title=Private_Corkboard.title AND Corkboard.owner_email=Private_Corkboard.owner_email" +
                $"WHERE Corkboard.owner_email=User.email AND PushPin.title=Corkboard.title" +
                $"GROUP BY name" +
                $"ORDER BY COUNT(Corkboard.title) DESC");

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
