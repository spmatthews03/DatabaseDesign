using API.Helpers;
using Corkboard.UI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corkboard.API.Helpers
{
    public class PushpinHelper
    {
        public static List<Pushpin> GetPushpinsForCorkboard()
        {
            var pushpinRows = DatabaseHelper.ExecuteQuery("GET ALL PUSHPINS FOR CORKBOARD");
            var pushpinsList = new List<Pushpin>();
            foreach (DataRow row in pushpinRows.Rows)
            {
                var pushpin = new Pushpin();
                pushpin.Description = row.GetValueInRow("Description");
                pushpin.Url = row.GetValueInRow("Url");
                pushpinsList.Add(pushpin);
            }

            return pushpinsList;
        }
    }
}
