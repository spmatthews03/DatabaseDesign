﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corkboard.UI.Models
{
    public class Corkboard
    {
        /// <summary>
        /// Represents the category of the corkboard.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Represents when the corkboard was last updated.
        /// </summary>
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// Represents the pushpins on this corkboard.
        /// </summary>
        public List<Pushpin> Pushpins { get; set; }

        /// <summary>
        /// Represents the title of the corkboard.
        /// </summary>
        public string Title { get; set; }
    }
}
