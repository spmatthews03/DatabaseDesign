namespace Corkboard.API.Models
{
    public class PopularTags
    {
        public PopularTags(string tag, int numPushPins,  int numUniqueCorkboards)
        {
            Tag = tag;
            Pushpins = numPushPins;
            UniqueCorkboards = numUniqueCorkboards;
        }

        /// <summary>
        /// Represents the amount of pushpins this tag is used for.
        /// </summary>
        public int Pushpins { get; set; }

        /// <summary>
        /// Represents the tag name.
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Represents the amount of unique corkboards this tag is used for.
        /// </summary>
        public int UniqueCorkboards { get; set; }
    }
}
