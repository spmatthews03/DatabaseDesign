using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corkboard.API.Models
{
    public class User
    {
        public User(string email, string name,  string pin)
        {
            Email = email;
            Name = name;
            Pin = pin;
        }

        /// <summary>
        /// Represents the user's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Represents the user's followers.
        /// </summary>
        public List<User> Followers { get; set; }

        /// <summary>
        /// Represents the user's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents the user's pin.
        /// </summary>
        public string Pin { get; set; }
    }
}
