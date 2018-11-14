using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Corkboard.API.Helpers
{
    public static class CorkboardHelper

    {
        public static List<Models.Corkboard> GetUsersCorkboards()
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

        public static List<Models.Corkboard> GetUsersPublicCorkboards()
        {
            return GetUsersCorkboards().Where(x => x.IsPrivate.Equals(false)).ToList();
        }
    }
}
