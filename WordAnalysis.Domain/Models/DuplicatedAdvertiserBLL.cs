namespace WordAnalysis.Domain.Models
{
    /// <summary>
    /// Duplicated advertiser object in business logic layer
    /// </summary>
    public class DuplicatedAdvertiserBLL
    {
        /// <summary>
        /// Duplicated advertiser Id
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// Key from full text search
        /// </summary>
        public string Key { set; get; }
        /// <summary>
        /// Rank from full text search
        /// </summary>
        public int Rank { set; get; }
    }
}
