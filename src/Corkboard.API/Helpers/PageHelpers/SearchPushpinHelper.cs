using System.Collections.Generic;
using System.Linq;

namespace Corkboard.API.Helpers.PageHelpers
{
    public static class SearchPushpinHelper
    {
        public static List<Models.Pushpin> GetMatchingPushpins(string searchQuery)
        {
            var matchingPushpins = new List<Models.Pushpin>();
            var publicCorkboards = CorkboardHelper.GetUsersPublicCorkboards();

            foreach (var corkboard in publicCorkboards)
            {
                var pushpins = PushpinHelper.GetPushpinsForCorkboard();

                //Check for search query in corkboard category
                if (corkboard.Category.Contains(searchQuery))
                {
                    matchingPushpins.AddRange(pushpins);
                }
                else
                {
                    foreach (var pushpin in pushpins)
                    {
                        //Check for search query in pushpin description
                        if (pushpin.Description.Contains(searchQuery))
                        {
                            matchingPushpins.Add(pushpin);
                        }
                        else
                        {
                            //Check for search query in pushpin tags
                            if (pushpin.Tags.Any(x => x.Contains(searchQuery)))
                            {
                                matchingPushpins.Add(pushpin);
                            }
                        }

                    }
                }
            }

            return matchingPushpins;
        }
    }
}
