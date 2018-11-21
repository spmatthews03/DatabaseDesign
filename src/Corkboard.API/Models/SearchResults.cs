namespace Corkboard.API.Models
{
    /// <summary>
    /// For pushpin search.
    /// </summary>
    public class SearchResults
    {
        public SearchResults(string corkboard, string description, string owner, 
            string owner_email, string url, string dateTime, string title)
        {
            Corkboard = corkboard;
            Description = description;
            Owner = owner;
            OwnerEmail = owner_email;
            Url = url;
            DateTime = dateTime;
            Title = title;
        }

        /// <summary>
        /// Represents the corkboards title.
        /// </summary>
        public string Corkboard { get; set; }

        /// <summary>
        /// Represents the pushpin's description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Represents the corkboards owner.
        /// </summary>
        public string Owner { get; set; }
        
        /// <summary>
        /// Represents the owner's email.
        /// </summary>
        public string OwnerEmail { get; set; }

        /// <summary>
        /// Represents the url of the pushpin.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Represents the date/time for the pushpin.
        /// </summary>
        public string DateTime { get; set; }

        /// <summary>
        /// Represents the title of the pushpin.
        /// </summary>
        public string Title { get; set; }
    }
}
