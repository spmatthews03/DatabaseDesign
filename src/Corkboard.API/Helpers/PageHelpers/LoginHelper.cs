using System;

namespace Corkboard.API.Helpers
{
    public static class LoginHelper
    {
        public static Models.User ValidateLogin(string userName, int pin)
        {
            var userTable = DatabaseHelper.ExecuteQuery("QUERY TO GET USER WITH USERNAME");
            if (userTable.Rows.Count > 0  )
            {
                var actualPin = Convert.ToInt32(userTable.GetValueInTable("Pin"));
                if (actualPin.Equals(pin))
                {
                    return new Models.User(userTable.GetValueInTable("Email"), userTable.GetValueInTable("Name"), actualPin);
                }
            }

            return null;
        }
    }
}
