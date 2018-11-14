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
        public static Models.User Login(string email, int pin)
        {
            // TODO - fill in query.
            var userTable = DatabaseHelper.ExecuteQuery("QUERY TO GET USER WITH USERNAME");
            if (userTable.Rows.Count > 0)
            {
                var actualPin = Convert.ToInt32(userTable.GetValueInTable("Pin"));
                if (actualPin.Equals(pin))
                {
                    // TODO - update to return all info for that user from the table.
                    return new Models.User(userTable.GetValueInTable("Email"), userTable.GetValueInTable("Name"), actualPin);
                }
            }

            return null;
        }
    }
}
