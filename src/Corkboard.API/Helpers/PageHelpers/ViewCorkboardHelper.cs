using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corkboard.API.Helpers.PageHelpers
{
    public static class ViewCorkboardHelper
    {
        public static void FollowCorkboardOwner()
        {
            DatabaseHelper.ExecuteQuery("SQL TO FOLLOW CORKBOARD OWNER");
        }

        public static void WatchCorkboard()
        {
            DatabaseHelper.ExecuteQuery("SQL TO WATCH CORKBOARD");
        }
    }
}
