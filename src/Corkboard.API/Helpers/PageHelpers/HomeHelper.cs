using Corkboard.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Corkboard.API.Helpers.PageHelpers
{
    public static class HomeHelper
    {
        /// <summary>
        /// Gets a list of recently updated corkboards.
        /// </summary>
        /// <param name="currentUser">Represents the currently logged in user.</param>
        /// <returns>Returns the last four recently updated corkboards, or an empty list.</returns>
        public static List<Models.Corkboard> GetRecentlyUpdatedCorkboards(User currentUser)
        {
            var corkboards = CorkboardHelper.GetRecentUpdatedCorkboards(currentUser);
            corkboards.OrderBy(x => x.LastUpdate);
            return corkboards.GetRange(0, 4);
        }
    }
}
