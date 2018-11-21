using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corkboard.API.Models
{
    public class Corkboard
    {
        /// <summary>
        /// Represents the category of the corkboard.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Represents whether or not the corkboard is private.
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Represents when the corkboard was last updated.
        /// </summary>
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// Represents the owner of the corkboard.
        /// </summary>
        public User Owner { get; set; }

        /// <summary>
        /// Represents the pushpins on this corkboard.
        /// </summary>
        public List<Pushpin> Pushpins { get; set; }

        /// <summary>
        /// Represents the title of the corkboard.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Represents the watchers of the corkboard.
        /// </summary>
        public List<User> Watchers { get; set; } = new List<User>();

        /// <summary>
        /// Password if the corkboard is private
        /// </summary>
        public string Password { get; set; }
    }
}
