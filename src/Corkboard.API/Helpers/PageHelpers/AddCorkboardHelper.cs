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
            DatabaseHelper.ExecuteQuery($"INSERT INTO corkboard ( title, visibility, owner_email, category_type) VALUES ('{corkboard.Title}', {GetCorkboardVisibility(corkboard.IsPrivate)}, '{owner.Email}', '{corkboard.Category}');");
        }

        /// <summary>
        /// Returns whether this corkboard already exists for the user. 
        /// </summary>
        public static bool CheckCorkboardExists(Models.User user, string title)
        {
            return CorkboardHelper.GetUserCorkboards(user).Exists(x => x.Title.Equals(title));
        }

        /// <summary>
        /// Gets all the possible categories for a corkboard.
        /// </summary>
        public static List<string> GetCategories()
        {
            var categoryResult = DatabaseHelper.ExecuteQuery("Select * from category");
            return categoryResult.Rows.GetValueInRows("type");
        }

        private static int GetCorkboardVisibility(bool isPrivate)
        {
            if (isPrivate)
            {
                return 1;
            }

            return 0;
        }
    }
}
