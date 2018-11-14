namespace Corkboard.API.Models
{
    public class Sites
    {
        /// <summary>
        /// Represents the pushpins that have the base site url.
        /// </summary>
        public int Pushpins { get; set; }

        /// <summary>
        /// Represents the base site url. i.e. www.amazon.com
        /// </summary>
        public string Site { get; set; }
    }
}
