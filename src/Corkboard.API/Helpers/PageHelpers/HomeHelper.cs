﻿using System.Collections.Generic;
using System.Linq;

namespace Corkboard.API.Helpers.PageHelpers
{
    public static class HomeHelper
    {
        public static List<Models.Corkboard> GetRecentlyUpdatedCorkboards()
        {
            var corkboards = CorkboardHelper.GetUsersCorkboards();
            corkboards.OrderBy(x => x.LastUpdate);
            return corkboards.GetRange(0, 4);

        }
    }
}
