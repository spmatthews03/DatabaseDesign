using System.Collections.Generic;

namespace Corkboard.API.Helpers
{
    public static class AddCorkboardHelper
    {
        /// <summary>
        /// Adds a corkboard for a user.
        /// </summary>
        /// <param name="owner">User to add the corkboard for.</param>
        /// <param name="corkboard">Corkboard to add.</param>
        public static void AddCorkboard(Models.User owner, Models.Corkboard corkboard)
        {
            DatabaseHelper.ExecuteQuery("ADD CORKBOARD FOR A USER.");
        }

        /// <summary>
        /// Returns whether this corkboard already exists for the user. 
        /// </summary>
        public static bool CheckCorkboardExists(Models.User user, string title)
        {
            // Might be able to remove the check of the owner's email as that should be checked in 'GetUserCorkboards'.
            return CorkboardHelper.GetUserCorkboards(user).Exists(x => x.Title.Equals(title) && x.Owner.Email.Equals(user.Email));
        }

        /// <summary>
        /// Gets all the possible categories for a corkboard.
        /// </summary>
        public static List<string> GetCategories()
        {
            return null;
        }
    }
}
