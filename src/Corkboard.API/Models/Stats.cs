using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corkboard.API.Models
{
    public class Stats
    {
        /// <summary>
        /// Represents the amount of private corkboards for the user.
        /// </summary>
        public int PrivateCorkboards { get; set; }

        /// <summary>
        /// Represents the amount of private pushpins for the user.
        /// </summary>
        public int PrivatePushpins { get; set; }

        /// <summary>
        /// Represents the amount of public corkboards for the user.
        /// </summary>
        public int PublicCorkboards { get; set; }

        /// <summary>
        /// Represents the amount of public pushpins for the user.
        /// </summary>
        public int PublicPushpins { get; set; }

        /// <summary>
        /// Represents the user's full name.
        /// </summary>
        public string User { get; set; }
    }
}
