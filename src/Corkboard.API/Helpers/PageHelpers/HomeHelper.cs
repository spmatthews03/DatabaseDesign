using Corkboad.API.Helpers;
using Corkboard.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corkboard.API.Helpers.PageHelpers
{
    public class HomeHelper
    {
        public List<CorkboardModel> GetRecentlyUpdatedCorkboards()
        {
            var corkboards = CorkboardHelper.GetUsersCorkboards();
            corkboards.OrderBy(x => x.LastUpdate);
            return corkboards.GetRange(0, 4);

        }
    }
}
