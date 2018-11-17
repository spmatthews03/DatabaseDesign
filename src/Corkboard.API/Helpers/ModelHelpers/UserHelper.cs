using Corkboard.API.Models;
using System.Collections.Generic;

namespace Corkboard.API.Helpers
{
    public static class UserHelper
    {
        /// <summary>
        /// Gets the followers of a user.
        /// </summary>
        /// <param name="user">User to get the followers of.</param>
        /// <returns>Returns the users followers, empty list if they have none.</returns>
        public static List<User> GetUserFollowers(string userEmail)
        {
            var followerResults = DatabaseHelper.ExecuteQuery($"SELECT * FROM follows WHERE email = '{userEmail}'");
            var followerEmails = followerResults.Rows.GetValueInRows("follower_email");
            var users = new List<User>();
            foreach (var email in followerEmails)
            {
                users.Add(GetUserByEmail(userEmail));
            }

            return users;
        }

        /// <summary>
        /// Gets a user by their email.
        /// </summary>
        /// <param name="user">User to get the followers of.</param>
        /// <returns>Returns the user with the specified email.</returns>
        public static User GetUserByEmail(string userEmail)
        {
            var userResults = DatabaseHelper.ExecuteQuery($"SELECT * FROM user WHERE email = '{userEmail}'");
            if (userResults?.Rows.Count > 0)
            {
                var user = new User(
                    userResults.GetValueInTable("Email"),
                    null,
                    userResults.GetValueInTable("Name"),
                    userResults.GetValueInTable("Pin"));

                return user;
            }

            return null;
        }
    }
}