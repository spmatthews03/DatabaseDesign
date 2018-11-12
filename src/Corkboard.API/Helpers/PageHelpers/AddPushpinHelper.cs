using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corkboard.API.Helpers.PageHelpers
{
    public class AddPushpinHelper
    {
        /// <summary>
        /// Adds a pushpin to the corkboard. 
        /// </summary>
        public void AddPushpinToCorkboard()
        {
            DatabaseHelper.ExecuteQuery("ADD PUSHPIN TO CORKBOARD");
        }
    }
}
