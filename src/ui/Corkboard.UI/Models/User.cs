using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corkboard.UI.Models
{
    public class User
    {
        /// <summary>
        /// Represents the user's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Represents the user's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents the user's pin.
        /// </summary>
        public int Pin { get; set; }
    }
}
