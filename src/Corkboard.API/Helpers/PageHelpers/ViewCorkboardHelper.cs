using Corkboard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corkboard.API.Helpers.PageHelpers
{
    public static class ViewCorkboardHelper
    {
        public static void FollowCorkboard(User owner, User follower)
        {
            DatabaseHelper.ExecuteQuery("SQL TO FOLLOW CORKBOARD OWNER");
        }

        public static void UnfollowCorkboard(User owner, User follower)
        {

        }

        public static void UnwatchCorkboard(User owner, User follower, string title)
        {

        }

        public static void WatchCorkboard(User owner, User follower, string title)
        {
            DatabaseHelper.ExecuteQuery("SQL TO WATCH CORKBOARD");
        }
    }
}
