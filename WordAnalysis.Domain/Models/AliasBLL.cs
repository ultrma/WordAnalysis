namespace WordAnalysis.Domain.Models
{
    /// <summary>
    /// Alias object in business logic layer
    /// </summary>
    public class AliasBLL
    {
        /// <summary>
        /// Alias record Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Advertiser name
        /// </summary>
        public string Advertiser { get; set; }
        /// <summary>
        /// Possible Alias name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Rank from full text search
        /// </summary>
        public int Rank { get; set; }
    }
}
