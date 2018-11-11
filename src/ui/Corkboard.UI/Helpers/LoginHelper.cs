using Corkboard.UI.Models;
using System;

namespace Corkboard.UI.Helpers
{
    public class LoginHelper
    {
        public User ValidateLogin(string userName, int pin)
        {
            var userTable = DatabaseHelper.ExecuteQuery("");
            if (userTable.Rows.Count > 0  )
            {
                var actualPin = Convert.ToInt32(userTable.GetValueInTable("Pin"));
                if (actualPin.Equals(pin))
                {
                    return new User(userTable.GetValueInTable("Email"), userTable.GetValueInTable("Name"), actualPin);
                }
            }

            return null;
        }
    }
}
