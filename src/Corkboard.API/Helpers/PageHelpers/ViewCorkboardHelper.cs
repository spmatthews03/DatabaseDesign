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
        public static void FollowUser(User owner, User follower)
        {
            DatabaseHelper.ExecuteQuery($"INSERT INTO follows ( email, follower_email) VALUES ('{owner.Email}', '{follower.Email}');");
        }

        public static void UnfollowUser(User owner, User follower)
        {
            DatabaseHelper.ExecuteQuery($"DELETE FROM follows WHERE email = '{owner.Email}' AND follower_email = '{follower.Email}'");
        }

        public static void UnwatchCorkboard(User owner, User follower, string title)
        {
            DatabaseHelper.ExecuteQuery($"DELETE FROM watch WHERE email = '{follower.Email}' AND title = '{title}' AND owner_email = '{owner.Email}'");

        }

        public static void WatchCorkboard(User owner, User follower, string title)
        {
            DatabaseHelper.ExecuteQuery($"INSERT INTO Watch(email, title, owner_email) VALUES('{follower.Email}', '{title}', '{owner.Email}');");
        }
    }
}
