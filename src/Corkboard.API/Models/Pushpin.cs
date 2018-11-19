using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corkboard.API.Models
{
    public class Pushpin
    {
        public Pushpin(string title, string dateTime, string owner_email, string description, string url, List<string> tags) {
            this.Title = title;
            this.DateTime = dateTime;
            this.Owner_Email = owner_email;
            this.Description = description;
            this.Url = url;
            this.Tags = tags;
            this.Likes = new List<User>();
            this.Comments = new List<Comment>();
        }

        public Pushpin(string title, string dateTime, string owner_email, string description, string url, List<string> tags, List<User> likes, List<Comment> comments)
        {
            this.Title = title;
            this.DateTime = dateTime;
            this.Owner_Email = owner_email;
            this.Description = description;
            this.Url = url;
            this.Tags = tags;
            this.Likes = likes;
            this.Comments = comments;
        }

        public Pushpin() { }

        /// <summary>
        /// Represents the title of the corkboard the pushpin belongs to.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Represents the dateTime of the pushpin.
        /// </summary>
        public string DateTime { get; set; }

        /// <summary>
        /// Represents the owner email of the corkboard the pushpin belongs to.
        /// </summary>
        public string Owner_Email { get; set; }

        /// <summary>
        /// Represents the description for the pushpin.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Represents the url to the pushpin's image.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Represents the tags for the pushpin.
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Represents the users that have liked the pushpin.
        /// </summary>
        public List<User> Likes { get; set; }

        /// <summary>
        /// Represents the comments on the pushpin.
        /// </summary>
        public List<Comment> Comments { get; set; }
    }
}
