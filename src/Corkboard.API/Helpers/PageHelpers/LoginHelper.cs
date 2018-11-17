using System;

namespace Corkboard.API.Helpers
{
    public static class LoginHelper
    {
        /// <summary>
        /// Attempts to locate the user in the database. Psuedo login.
        /// </summary>
        /// <param name="email">Email of the user.</param>
        /// <param name="pin">Pin of the user.</param>
        /// <returns>Returns all the user's information from the database, if not found, returns null.</returns>
        public static Models.User Login(string email, string pin)
        {
            var user = UserHelper.GetUserByEmail(email);
            if(user != null && user.Pin.Equals(pin))
            {
                return user;
            }

            return null;
        }
    }
}
