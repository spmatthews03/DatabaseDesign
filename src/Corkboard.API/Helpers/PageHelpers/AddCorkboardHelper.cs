namespace Corkboard.API.Helpers
{
    public static class AddCorkboardHelper
    {
        /// <summary>
        /// If a corkboard exists for the current user. 
        /// </summary>
        public static bool CorkboardExistsForUser(string title, Models.User user)
        {
            return CorkboardHelper.GetUserCorkboards(user).Exists(x => x.Title.Equals(title) && x.Owner.Email.Equals(user.Email));
        }

        /// <summary>
        /// Adds a corkboard for a user.
        /// </summary>
        public static void AddCorkboardForUser()
        {
            DatabaseHelper.ExecuteQuery("ADD CORKBOARD FOR A USER.");
        }
    }
}
