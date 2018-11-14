namespace Corkboard.API.Helpers
{
    public class AddCorkboardHelper
    {
        /// <summary>
        /// If a corkboard exists for the current user. 
        /// </summary>
        public bool CorkboardExistsForUser(string title, Models.User user)
        {
            return CorkboardHelper.GetUsersCorkboards().Exists(x => x.Title.Equals(title) && x.Owner.Email.Equals(user.Email));
        }

        /// <summary>
        /// Adds a corkboard for a user.
        /// </summary>
        public void AddCorkboardForUser()
        {
            DatabaseHelper.ExecuteQuery("ADD CORKBOARD FOR A USER.");
        }
    }
}
