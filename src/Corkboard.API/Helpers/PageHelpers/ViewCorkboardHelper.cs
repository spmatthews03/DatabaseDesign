using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corkboard.API.Helpers.PageHelpers
{
    public class ViewCorkboardHelper
    {
        public void FollowCorkboardOwner()
        {
            DatabaseHelper.ExecuteQuery("SQL TO FOLLOW CORKBOARD OWNER");
        }

        public void WatchCorkboard()
        {
            DatabaseHelper.ExecuteQuery("SQL TO WATCH CORKBOARD");
        }
    }
}
