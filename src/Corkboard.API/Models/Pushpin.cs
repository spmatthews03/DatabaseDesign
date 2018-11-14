using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corkboard.API.Models
{
    public class Pushpin
    {
        /// <summary>
        /// Represents the description for the pushpin.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Represents the tags for the pushpin.
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Represents the url to the pushpin's image.
        /// </summary>
        public string Url { get; set; }
    }
}
