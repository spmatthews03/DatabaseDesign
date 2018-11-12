using Corkboard.API.Helpers;
using Corkboard.UI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Corkboad.API.Helpers
{
    public static class CorkboardHelper

    {
        public static List<CorkboardModel> GetUsersCorkboards()
        {
            var corkboardRows = DatabaseHelper.ExecuteQuery("GET ALL CORKBOARDS FOR USER");
            var corkboardList = new List<CorkboardModel>();
            foreach (DataRow row in corkboardRows.Rows)
            {
                var newCorkboad = new CorkboardModel();
                newCorkboad.Category = row.GetValueInRow("Category");
                newCorkboad.LastUpdate = Convert.ToDateTime(row.GetValueInRow("LastUpdate"));
                newCorkboad.Title = row.GetValueInRow("Title");
                newCorkboad.Pushpins = PushpinHelper.GetPushpinsForCorkboard();
                corkboardList.Add(newCorkboad);
            }

            return corkboardList;
        }

        public static List<CorkboardModel> GetUsersPublicCorkboards()
        {
            return GetUsersCorkboards().Where(x => x.IsPrivate.Equals(false)).ToList();
        }
    }
}
