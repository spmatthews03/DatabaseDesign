namespace Corkboard.API.Models
{
    /// <summary>
    /// For pushpin search.
    /// </summary>
    public class SearchResults
    {
        /// <summary>
        /// Represents the corkboards title.
        /// </summary>
        public string Corkboard { get; set; }

        /// <summary>
        /// Represents the pushpin's description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Represent's the corkboards owner.
        /// </summary>
        public string Owner { get; set; }
    }
}
