using System.Collections.Generic;
using System.Data;

namespace Corkboard.API.Helpers
{
    public class PushpinHelper
    {
        public static List<Models.Pushpin> GetPushpinsForCorkboard()
        {
            var pushpinRows = DatabaseHelper.ExecuteQuery("GET ALL PUSHPINS FOR CORKBOARD");
            var pushpinsList = new List<Models.Pushpin>();
            foreach (DataRow row in pushpinRows.Rows)
            {
                var pushpin = new Models.Pushpin();
                pushpin.Description = row.GetValueInRow("Description");
                pushpin.Url = row.GetValueInRow("Url");
                pushpinsList.Add(pushpin);
            }

            return pushpinsList;
        }
    }
}
