using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corkboard.API.Models
{
    public class Comment
    {
        public Comment(string user, DateTime dt, string text)
        {
            User = user;
            DateTime = dt;
            Value = text;
        }

        /// <summary>
        /// Represents the user's name who left the comment.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Represents the date/time the comment was left.
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Represents the comment.
        /// </summary>
        public string Value { get; set; }
    }
}
