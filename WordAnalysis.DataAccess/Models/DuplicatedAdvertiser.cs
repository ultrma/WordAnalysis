using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAnalysis.DataAccess.Models
{
    /// <summary>
    /// Entity for the response of GetDuplicatedNames 
    /// </summary>
    public class DuplicatedAdvertiser
    {
        /// <summary>
        /// AdvertiserId
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// The text we found from similar advertiser
        /// </summary>
        public string Key { set; get; }

        /// <summary>
        /// Rank value from ContainsTable expression.
        /// The value range is from 0 through 1000.
        /// The rank values indicate only a relative order of relevance of the rows in the result set, with a lower value indicating lower relevance. 
        /// For more detail, please refer to the following link.
        /// https://docs.microsoft.com/en-us/sql/relational-databases/search/limit-search-results-with-rank?view=sql-server-ver15
        /// </summary>
        public int Rank { set; get; }
    }
}
